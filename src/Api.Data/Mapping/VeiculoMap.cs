using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{    
     public class VeiculoMap : IEntityTypeConfiguration<VeiculoEntity>
    {
        public void Configure(EntityTypeBuilder<VeiculoEntity> builder)
        {
           builder.ToTable("Veiculo");

            builder.HasKey(v => v.Id);

            builder.Property(v => v.Placa)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(v => v.Marca)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(v => v.Modelo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(v => v.Ano)
                .IsRequired();

            builder.Property(v => v.CreateAt)
                .IsRequired();

            builder.Property(v => v.UpdateAt);
        }
    }
}