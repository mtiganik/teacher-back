using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using teacher.Db.Data;
using teacher.Models.Mappings;
using teacher.Services.Interfaces;
using teacher.Services.Services;

namespace teacher.Extensions
{
    public static class ServiceExtensions
    {
        
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();

        public static string GetConnectionStringWithValues(bool isDevelopment, string ConnString)
        {
            string envr = isDevelopment ? "DEVELOP_" : "PRODUCTION_";

            string user = envr + "USER", pw = envr + "PW";

            return ConnString.Replace("{USERNAME}", Environment.GetEnvironmentVariable(user)).Replace("{PASSWORD}", Environment.GetEnvironmentVariable(pw));
        }

        public static void ConfigureSqlContext(this IServiceCollection services, string connectionString) =>

            services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlServer(connectionString,
                    b => b.MigrationsAssembly("teacher.Db")));

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureMapping(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
            var mapperConfig = new MapperConfiguration(map =>
            {
                map.AddProfile<PostMappingProfile>();
            });
            services.AddSingleton(mapperConfig.CreateMapper());

        }

        public static void AddConfigs(this IServiceCollection services, string fileName)
        {
            var filepath = Directory.GetCurrentDirectory();
            filepath = filepath + fileName;
            Load(filepath);
        }

        private static void Load(string filePath)
        {
            if (!File.Exists(filePath))
                return;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(
                    '=',
                    StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2)
                    continue;

                Environment.SetEnvironmentVariable(parts[0], parts[1]);
            }
        }

    }
}
