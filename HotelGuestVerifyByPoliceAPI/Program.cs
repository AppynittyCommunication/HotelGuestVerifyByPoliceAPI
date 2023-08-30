using HotelGuestVerifyByPolice.DataContext.Data;
using HotelGuestVerifyByPolice.DataContext.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAuthorization();

// Add configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IRepository, Repository>();
builder.Services.AddDbContext<ApplicationDbContext>();


builder.Services.AddCors(p => p.AddPolicy("MyCorsPolicy", build =>
{
    //build.WithOrigins("http://103.26.97.75:8080", "https://coreapi.ictsbm.com","http://localhost:3000", "https://localhost:3000").AllowAnyHeader().WithMethods("GET","POST");
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

app.UseAuthorization();

app.MapControllers();

app.Run();
