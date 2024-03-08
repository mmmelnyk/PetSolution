using Pet.Api.Models;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Hangfire.PostgreSql;
using Pet.Services.General.Interfaces;
using Pet.Services.General;
using HangfireBasicAuthenticationFilter;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DefaultDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Hangfire client
builder.Services.AddHangfire(config => config
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UsePostgreSqlStorage(options =>
    {
        options.UseNpgsqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"));
    }));

// Hangfire server
builder.Services.AddHangfireServer();

builder.Services.AddControllers();

builder.Services.AddScoped<IMerchService, MerchService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IMaintenanceService, MaintenanceService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseHangfireDashboard(); //Will be available under http://localhost:5000/hangfire"
app.MapHangfireDashboard("/hangfire", new DashboardOptions() 
{
    DashboardTitle = "My pet project Dashboard",
    Authorization = new[] { 
        new HangfireCustomBasicAuthenticationFilter()
        {
            Pass = "password",
            User = "admin"
        }
    }
}); //Will be available under http://localhost:5000/hangfire"

app.UseRouting();
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
