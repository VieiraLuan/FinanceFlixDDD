using FinanceFlix.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data.Entity.ModelConfiguration;


namespace FinanceFlix.Data.Mappings
{
    public class CursoVideoMapping : IEntityTypeConfiguration<CursoVideo>
    {
        public void Configure(EntityTypeBuilder<CursoVideo> builder)
        {


            //PK
            builder.HasKey
            (builder => new { builder.CursoId, builder.VideoId }).HasName("ID_CURSO_VIDEO");

            builder.HasOne(c => c.Curso)
            .WithMany(c => c.CursosVideos)
            .HasForeignKey(c => c.CursoId);

            builder.HasOne(c => c.Video)
            .WithMany(c => c.CursosVideos)
            .HasForeignKey(c => c.VideoId);

            //Columns
            builder.Property(c => c.CreatedDate)
             .HasColumnName("DT_CRIACAO")
             .IsRequired(false);


            builder.Property(c => c.LastModifiedDate)
                .HasColumnName("DT_ULTIMA_MODIFICACAO")
                .IsRequired(false);

            //TB
            builder.ToTable("TB_CURSO_VIDEO");

        }


    }
}