using FluentValidation.AspNetCore;
using Reservio.AppDataContext;
using Reservio.Services.ReservationRepo;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Reservio.Services.PatientRepo;
using Microsoft.Extensions.Configuration;
using Reservio.Services.ClinicRepo;
using Reservio.Services.DotorRepo;
using Reservio.Services.BaseRepo;

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

// UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.öíí(x => x.AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials()
    .WithExposedHeaders("x-pagination"));

app.UseAuthorization();

app.MapControllers();

app.Run();
//saad update