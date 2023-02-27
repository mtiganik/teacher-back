using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NLog;
using teacher.Db.Data;
using teacher.Extensions;
using teacher.Services.Interfaces;
using teacher.Services.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConfigs("\\.env");
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
LoggerManager logger = new LoggerManager();


builder.Services.ConfigureCors();

builder.Services.ConfigureMapping();
builder.Services.ConfigureLoggerService();

string connString = ServiceExtensions.GetConnectionStringWithValues(builder.Environment.IsDevelopment(), builder.Configuration.GetConnectionString("sqlConnection"));


builder.Services.ConfigureSqlContext(connString);
builder.Services.ConfigureRepositoryManager();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
//app.MapGet("/");
app.UseCors("AllowAll");
app.MapControllers();
app.Run();
