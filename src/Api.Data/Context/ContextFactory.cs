using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
{
    try
    {
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "Api.Application");
        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
            .Build();

        var database = configuration["DATABASE"];

        var optionsBuilder = new DbContextOptionsBuilder<MyContext>();

        if (string.Equals(database, "SQLSERVER", StringComparison.OrdinalIgnoreCase))
        {
            var connectionString = configuration.GetConnectionString("SQLSERVER_CONNECTION");
            optionsBuilder.UseSqlServer(connectionString);
        }
        else
        {
            var connectionString = configuration.GetConnectionString("MYSQL_CONNECTION");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        return new MyContext(optionsBuilder.Options);
    }
    catch (Exception ex)
    {
        // Lance uma nova exceção com a mensagem completa para facilitar o debug
        throw new Exception($"Erro ao criar DbContext no design time: {ex.Message}", ex);
    }
}

    }
}
