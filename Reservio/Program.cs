using FluentValidation.AspNetCore;
using Reservio.AppDataContext;
using Reservio.Services.ReservationRepo;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Reservio.Services.PatientRepo;
using Microsoft.Extensions.Configuration;
using Reservio.Services.ClinicRepo;
using Reservio.Services.DotorRepo;

var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("S://LoggerHosptail/logger", rollingInterval: RollingInterval.Day)
    .CreateBootstrapLogger();
builder.Host.UseSerilog();
builder.Services.AddControllers()
    .AddFluentValidation(fv => {
        fv.RegisterValidatorsFromAssemblyContaining<Program>();
        fv.DisableDataAnnotationsValidation = true;
    });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IClinicRepository, ClinicRepository>();
builder.Services.AddScoped<IDoctorRepostriey, DoctorRepostriey>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
//saad update