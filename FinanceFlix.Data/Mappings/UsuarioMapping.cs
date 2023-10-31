using FinanceFlix.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceFlix.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //TB
            builder.ToTable("TB_USUARIO");

            //PK
            builder.HasKey(u => u.Id).HasName("ID_USUARIO");

            //Columns

            builder.Property(u => u.Nome)
            .HasColumnName("NOME_USUARIO")
            .HasMaxLength(80)
            .IsRequired();

            builder.Property(u => u.Email)
            .HasColumnName("EMAIL_USUARIO")
            .HasMaxLength(80)
            .IsRequired();

            builder.Property(u => u.Senha)
            .HasColumnName("SENHA_USUARIO")
            .HasMaxLength(80)
            .IsRequired();

            builder.Property(u => u.Tipo)
            .HasColumnName("TIPO_USUARIO")
            .HasMaxLength(80)
            .IsRequired(false);

            builder.Property(u => u.FotoUrl)
            .HasColumnName("FOTO_USUARIO")
            .HasMaxLength(80)
            .IsRequired(false);

            builder.Property(u => u.CreatedDate)
              .HasColumnName("DT_CRIACAO")
              .IsRequired(false);

            builder.Property(u=> u.LastModifiedDate)
                .HasColumnName("DT_ULTIMA_MODIFICACAO")
                .IsRequired(false);

            //No Relationship




        }
    }
}
