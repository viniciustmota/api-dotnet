using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
            .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            if (configuration.GetConnectionString("DATABASE").ToLower() == "SQLSERVER".ToLower())
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            else
            {
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));    
            }
            
            
            return new MyContext(optionsBuilder.Options);
        }
    }
}
