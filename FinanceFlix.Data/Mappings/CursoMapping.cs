using FinanceFlix.API.Entities;
using FinanceFlix.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Data.Mappings
{
    public class CursoMapping : IEntityTypeConfiguration<Curso>
    {

        public void Configure(EntityTypeBuilder<Curso> builder)
        {


            //PK
            builder.HasKey(c => c.Id).HasName("ID_CURSO");

            //Columns
            builder.Property(c => c.Nome)
            .HasColumnName("NOME_CURSO")
            .HasMaxLength(80)
            .IsRequired();

            builder.Property(c => c.Descricao)
            .HasColumnName("DESC_CURSO")
            .HasMaxLength(120)
            .IsRequired();

            builder.Property(c => c.ImagemUrl)
            .HasColumnName("URL_IMAGEM")
            .IsRequired(false);


            builder.Property(c => c.CreatedDate)
               .HasColumnName("DT_CRIACAO")
               .IsRequired(false);


            builder.Property(c => c.LastModifiedDate)
                .HasColumnName("DT_ULTIMA_MODIFICACAO")
                .IsRequired(false);

            //Relationships 1:N
            builder.HasOne(c => c.Categoria)
            .WithMany(c => c.Cursos)
            .HasForeignKey(c => c.CategoriaId)
            .HasPrincipalKey(c => c.Id)
            .OnDelete(DeleteBehavior.Restrict);

            //TB
            builder.ToTable("TB_CURSO");




        }


    }
}