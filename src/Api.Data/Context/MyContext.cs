using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        //é a forma do seu DbContext receber as configurações do 
        // Entity Framework Core de forma externa, através do
        // sistema de Injeção de Dependência.
        // Isso garante que seu DbContext seja configurável, flexível,
        // testável e que o framework possa gerenciar seu ciclo de vida
        // de maneira eficiente.
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
        }
    }
}
