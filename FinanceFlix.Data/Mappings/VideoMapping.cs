using FinanceFlix.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.ModelConfiguration;


namespace FinanceFlix.Data.Mappings
{
    public class VideoMapping: IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
           

            //PK
            builder.HasKey(c => c.Id).HasName("ID_VIDEO");

            //Columns
            builder.Property(c => c.Nome)
            .HasColumnName("NOME_VIDEO")
            .HasMaxLength(80)
            .IsRequired();

            builder.Property(c => c.Descricao)
            .HasColumnName("DESC_VIDEO")
            .HasMaxLength(120)
            .IsRequired();

            builder.Property(c => c.Url)
            .HasColumnName("URL_VIDEO")
            .HasMaxLength(200)
            .IsRequired();

            builder.Property(c => c.CreatedDate)
            .HasColumnName("DT_CRIACAO")
            .IsRequired();

            builder.Property(c => c.DuracaoSegundos)
            .HasColumnName("DURACAO_SEGUNDOS")
            .IsRequired();

            builder.Property( c=> c.FilePath)
            .HasColumnName("FILE_PATH")
            .HasMaxLength(200)
            .IsRequired(false);

            //TB
            builder.ToTable("TB_VIDEO");

        }
    }
}
