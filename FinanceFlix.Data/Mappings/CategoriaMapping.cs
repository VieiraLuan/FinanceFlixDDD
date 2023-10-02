using FinanceFlix.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Data.Mappings
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            

            //PK
            builder.HasKey(c => c.Id).HasName("ID_CATEGORIA");


            //Columns
            builder.Property(c => c.Nome)
            .HasColumnName("NOME_CATEGORIA")
            .HasMaxLength(80)
            .IsRequired();

            builder.Property(c => c.Descricao)
            .HasColumnName("DESC_CATEGORIA")
            .HasMaxLength(120)
            .IsRequired();

            
            builder.Property(c => c.CreatedDate)
            .HasColumnName("DT_CRIACAO")
            .IsRequired();

            //Relationships 1:N
            builder.HasMany(c => c.Cursos)
            .WithOne(c => c.Categoria)
            .HasForeignKey(c => c.Id)
            .HasPrincipalKey(c => c.Id)
            .OnDelete(DeleteBehavior.Restrict);

            //TB
            builder.ToTable("TB_CATEGORIA");

        }

    }
}
