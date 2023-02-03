using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NLog;
using teacher.Db.Data;
using teacher.Extensions;
using teacher.Services.Interfaces;
using teacher.Services.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConfigs();
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
LoggerManager logger = new LoggerManager();

Console.WriteLine(builder.Configuration.GetConnectionString("sqlConnection"));
builder.Services.ConfigureMapping();
builder.Services.ConfigureLoggerService();

string connString = ServiceExtensions.GetConnectionString(builder.Environment.IsDevelopment(), builder.Configuration.GetConnectionString("sqlConnection"));


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
app.MapControllers();
app.Run();
