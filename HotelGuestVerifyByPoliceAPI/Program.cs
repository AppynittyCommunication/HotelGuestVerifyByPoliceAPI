global using HotelGuestVerifyByPolice.DataContext.Data;
using HotelGuestVerifyByPolice.DataContext.Interface;
using HotelGuestVerifyByPoliceAPI.Middlewares;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Debug()
    .MinimumLevel.Error()
    .MinimumLevel.Fatal()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
//User this line to override the built-in loggers
builder.Host.UseSerilog();
//Use Serilog along with built-In loggers
builder.Logging.AddSerilog();
// Add services to the container.
builder.Services.AddTransient<ExceptionMiddleware>();

builder.Services.AddControllers();
builder.Services.AddAuthorization();

// Add configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IRepository, Repository>();
//builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultDBConn"),
        sqlServerOptionsAction: sqlOptions =>
        {
            // Enable transient error resiliency with retry options
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,           // Maximum number of retries
                maxRetryDelay: TimeSpan.FromSeconds(30), // Maximum delay between retries
                errorNumbersToAdd: null      // List of specific error numbers to trigger retries
            );
        });
});

builder.Services.AddCors(p => p.AddPolicy("MyCorsPolicy", build =>
{
    //build.WithOrigins("http://localhost:3000", "https://localhost:3000").AllowAnyHeader().WithMethods("GET","POST");
    build.AllowAnyOrigin().AllowAnyHeader().WithMethods("GET", "POST");
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseMiddleware<ApiKeyMiddleware>();
app.UseAuthorization();
//calling Exception Middleware
app.ConfigureExceptionMiddleware();

app.MapControllers();
app.UseCors();
app.Run();
