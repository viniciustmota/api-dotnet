﻿// <auto-generated />
using System;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20250728124932_AddTableVeiculo")]
    partial class AddTableVeiculo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Api.Domain.Entities.CepEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<Guid>("MunicipioId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Cep");

                    b.HasIndex("MunicipioId");

                    b.ToTable("Cep", (string)null);
                });

            modelBuilder.Entity("Api.Domain.Entities.MunicipioEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("CodIBGE")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<Guid>("UfId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("CodIBGE");

                    b.HasIndex("UfId");

                    b.ToTable("Municipio", (string)null);
                });

            modelBuilder.Entity("Api.Domain.Entities.UfEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Sigla")
                        .IsUnique();

                    b.ToTable("Uf", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "Acre",
                            Sigla = "AC"
                        },
                        new
                        {
                            Id = new Guid("7cc33300-586e-4be8-9a4d-bd9f01ee9ad8"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "Alagoas",
                            Sigla = "AL"
                        },
                        new
                        {
                            Id = new Guid("cb9e6888-2094-45ee-bc44-37ced33c693a"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "Amazonas",
                            Sigla = "AM"
                        },
                        new
                        {
                            Id = new Guid("409b9043-88a4-4e86-9cca-ca1fb0d0d35b"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "Amapá",
                            Sigla = "AP"
                        },
                        new
                        {
                            Id = new Guid("5abca453-d035-4766-a81b-9f73d683a54b"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "Bahia",
                            Sigla = "BA"
                        },
                        new
                        {
                            Id = new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "Ceará",
                            Sigla = "CE"
                        },
                        new
                        {
                            Id = new Guid("bd08208b-bfca-47a4-9cd0-37e4e1fa5006"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "Distrito Federal",
                            Sigla = "DF"
                        },
                        new
                        {
                            Id = new Guid("c623f804-37d8-4a19-92c1-67fd162862e6"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "Espírito Santo",
                            Sigla = "ES"
                        },
                        new
                        {
                            Id = new Guid("837a64d3-c649-4172-a4e0-2b20d3c85224"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "Goiás",
                            Sigla = "GO"
                        },
                        new
                        {
                            Id = new Guid("57a9e9f7-9aea-40fe-a783-65d4feb59fa8"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "Maranhão",
                            Sigla = "MA"
                        },
                        new
                        {
                            Id = new Guid("27f7a92b-1979-4e1c-be9d-cd3bb73552a8"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "Minas Gerais",
                            Sigla = "MG"
                        },
                        new
                        {
                            Id = new Guid("3739969c-fd8a-4411-9faa-3f718ca85e70"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "Mato Grosso do Sul",
                            Sigla = "MS"
                        },
                        new
                        {
                            Id = new Guid("29eec4d3-b061-427d-894f-7f0fecc7f65f"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "Mato Grosso",
                            Sigla = "MT"
                        },
                        new
                        {
                            Id = new Guid("8411e9bc-d3b2-4a9b-9d15-78633d64fc7c"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "Pará",
                            Sigla = "PA"
                        },
                        new
                        {
                            Id = new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "Paraíba",
                            Sigla = "PB"
                        },
                        new
                        {
                            Id = new Guid("ad5969bd-82dc-4e23-ace2-d8495935dd2e"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "Pernambuco",
                            Sigla = "PE"
                        },
                        new
                        {
                            Id = new Guid("f85a6cd0-2237-46b1-a103-d3494ab27774"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "Piauí",
                            Sigla = "PI"
                        },
                        new
                        {
                            Id = new Guid("1dd25850-6270-48f8-8b77-2f0f079480ab"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "Paraná",
                            Sigla = "PR"
                        },
                        new
                        {
                            Id = new Guid("43a0f783-a042-4c46-8688-5dd4489d2ec7"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "Rio de Janeiro",
                            Sigla = "RJ"
                        },
                        new
                        {
                            Id = new Guid("542668d1-50ba-4fca-bbc3-4b27af108ea3"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "Rio Grande do Norte",
                            Sigla = "RN"
                        },
                        new
                        {
                            Id = new Guid("924e7250-7d39-4e8b-86bf-a8578cbf4002"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "Rondônia",
                            Sigla = "RO"
                        },
                        new
                        {
                            Id = new Guid("9fd3c97a-dc68-4af5-bc65-694cca0f2869"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "Roraima",
                            Sigla = "RR"
                        },
                        new
                        {
                            Id = new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "Rio Grande do Sul",
                            Sigla = "RS"
                        },
                        new
                        {
                            Id = new Guid("b81f95e0-f226-4afd-9763-290001637ed4"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "Santa Catarina",
                            Sigla = "SC"
                        },
                        new
                        {
                            Id = new Guid("fe8ca516-034f-4249-bc5a-31c85ef220ea"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "Sergipe",
                            Sigla = "SE"
                        },
                        new
                        {
                            Id = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "São Paulo",
                            Sigla = "SP"
                        },
                        new
                        {
                            Id = new Guid("971dcb34-86ea-4f92-989d-064f749e23c9"),
                            CreateAt = new DateTime(2025, 6, 23, 13, 0, 0, 0, DateTimeKind.Utc),
                            Nome = "Tocantins",
                            Sigla = "TO"
                        });
                });

            modelBuilder.Entity("Api.Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c3f0b2a1-e4d5-4f67-890a-1234567890ab"),
                            CreateAt = new DateTime(2025, 6, 13, 10, 0, 0, 0, DateTimeKind.Utc),
                            Email = "vinicius@mail.com",
                            Name = "Vinícius",
                            UpdateAt = new DateTime(2025, 6, 13, 10, 0, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("Api.Domain.Entities.VeiculoEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Veiculo", (string)null);
                });

            modelBuilder.Entity("Api.Domain.Entities.CepEntity", b =>
                {
                    b.HasOne("Api.Domain.Entities.MunicipioEntity", "Municipio")
                        .WithMany("Ceps")
                        .HasForeignKey("MunicipioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Municipio");
                });

            modelBuilder.Entity("Api.Domain.Entities.MunicipioEntity", b =>
                {
                    b.HasOne("Api.Domain.Entities.UfEntity", "Uf")
                        .WithMany("Municipios")
                        .HasForeignKey("UfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Uf");
                });

            modelBuilder.Entity("Api.Domain.Entities.MunicipioEntity", b =>
                {
                    b.Navigation("Ceps");
                });

            modelBuilder.Entity("Api.Domain.Entities.UfEntity", b =>
                {
                    b.Navigation("Municipios");
                });
#pragma warning restore 612, 618
        }
    }
}
