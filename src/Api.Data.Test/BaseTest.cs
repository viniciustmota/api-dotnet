using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Data.Test;

public abstract class BaseTest
{
    public BaseTest()
    {

    }

    public class DbTeste : IDisposable
    {
        private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";

        public ServiceProvider ServiceProvider { get; private set; }

        public DbTeste()
        {
            var serviceCollection = new ServiceCollection();
            var connectionString = $"Persist Security Info=True;Server=172.23.0.1;Database={dataBaseName};User=viniciustmota;Password=1234";
            serviceCollection.AddDbContext<MyContext>(o =>
                o.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)), ServiceLifetime.Transient
            );

            ServiceProvider = serviceCollection.BuildServiceProvider();
            using (var context = ServiceProvider.GetRequiredService<MyContext>())
            {
                context.Database.EnsureCreated();
            }
        }
        public void Dispose()
        {
            using (var context = ServiceProvider.GetRequiredService<MyContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}