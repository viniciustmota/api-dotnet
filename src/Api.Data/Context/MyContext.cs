using Api.Data.Mapping;
using Api.Data.Seeds;
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

            modelBuilder.Entity<UfEntity>(new UfMap().Configure);
            modelBuilder.Entity<MunicipioEntity>(new MunicipioMap().Configure);
            modelBuilder.Entity<CepEntity>(new CepMap().Configure);

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = new Guid("c3f0b2a1-e4d5-4f67-890a-1234567890ab"), // <-- GUID FIXO!

                    Name = "Administrador",
                    Email = "mfrinfo@mail.com",

                    // Use um valor de data e hora estático e fixo.
                    // É recomendado usar DateTimeKind.Utc para consistência.
                    CreateAt = new DateTime(2025, 6, 13, 10, 0, 0, DateTimeKind.Utc), // <-- DATA FIXA!
                    UpdateAt = new DateTime(2025, 6, 13, 10, 0, 0, DateTimeKind.Utc), // <-- DATA FIXA! (Ou null se permitido)
                }
            );

            UfSeeds.Ufs(modelBuilder);
        }
    }
}
