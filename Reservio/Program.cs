using FluentValidation.AspNetCore;
using Reservio.AppDataContext;
using Reservio.Services;
using Reservio.Services.ReservationRepo;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Reservio.Services.PatientRepo;

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
        fv.DisableDataAnnotationsValidation = true; }); 
//.AddNewtonsoftJson(options =>
//  options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<DataContext>(
    db => db.UseSqlServer(builder.Configuration["ConnectionStrings:Defualt"])
    );
builder.Services.AddScoped<IClinicRepository, ClinicRepository>();
builder.Services.AddScoped<IDoctorRepostriey, DoctorRepostriey>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
