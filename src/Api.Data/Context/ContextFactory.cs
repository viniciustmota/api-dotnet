using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //var connectionString = "Server=172.23.0.1;Port=3306;Database=dbAPI;Uid=viniciustmota;Pwd=1234;";
            var connectionString = "Server=172.23.0.1\\SQLEXPRESS2022;Initial Catalog=dbapi;MultipleActiveResultSets=true;User ID=sa;Password=DevSysth2025@";
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            //optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            optionsBuilder.UseSqlServer(connectionString);
            return new MyContext(optionsBuilder.Options);
        }
    }
}
