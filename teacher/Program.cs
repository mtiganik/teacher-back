using Microsoft.EntityFrameworkCore;
using NLog;
using teacher.Db.Data;
using teacher.Services.Interfaces;
using teacher.Services.Services;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
LoggerManager logger = new LoggerManager();

builder.Services.AddDbContext<RepositoryContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"),
b => b.MigrationsAssembly("teacher.Db")));

builder.Services.AddScoped<IServiceManager, ServiceManager>();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
app.MapGet("/", () => "Hello World!");

app.Run();
