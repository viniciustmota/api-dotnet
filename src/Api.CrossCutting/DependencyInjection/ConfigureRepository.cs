using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();


            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
            .Build();

            serviceCollection.AddDbContext<MyContext>(options =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
                if (configuration.GetConnectionString("DATABASE").ToLower() == "SQLSERVER".ToLower())
                {
                    optionsBuilder.UseSqlServer(connectionString);
                }
                else
                {
                    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));    
                }
            });
            
            
        }
    }
}
