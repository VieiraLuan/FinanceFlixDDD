﻿// <auto-generated />
using System;
using FinanceFlix.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace FinanceFlix.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231004024942_UpdatingRelationCursoCategoriaMigration")]
    partial class UpdatingRelationCursoCategoriaMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinanceFlix.API.Entities.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DT_CRIACAO");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("NVARCHAR2(120)")
                        .HasColumnName("DESC_CATEGORIA");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR2(80)")
                        .HasColumnName("NOME_CATEGORIA");

                    b.HasKey("Id")
                        .HasName("ID_CATEGORIA");

                    b.ToTable("TB_CATEGORIA", (string)null);
                });

            modelBuilder.Entity("FinanceFlix.API.Entities.Curso", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("RAW(16)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DT_CRIACAO");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("NVARCHAR2(120)")
                        .HasColumnName("DESC_CURSO");

                    b.Property<byte[]>("ImagemUrl")
                        .HasColumnType("RAW(2000)")
                        .HasColumnName("URL_IMAGEM");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR2(80)")
                        .HasColumnName("NOME_CURSO");

                    b.HasKey("Id")
                        .HasName("ID_CURSO");

                    b.HasIndex("CategoriaId");

                    b.ToTable("TB_CURSO", (string)null);
                });

            modelBuilder.Entity("FinanceFlix.API.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("FinanceFlix.API.Entities.Video", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DT_CRIACAO");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("NVARCHAR2(120)")
                        .HasColumnName("DESC_VIDEO");

                    b.Property<int>("DuracaoSegundos")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("DURACAO_SEGUNDOS");

                    b.Property<string>("FilePath")
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)")
                        .HasColumnName("FILE_PATH");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR2(80)")
                        .HasColumnName("NOME_VIDEO");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)")
                        .HasColumnName("URL_VIDEO");

                    b.HasKey("Id")
                        .HasName("ID_VIDEO");

                    b.ToTable("TB_VIDEO", (string)null);
                });

            modelBuilder.Entity("FinanceFlix.Domain.Entities.CursoVideo", b =>
                {
                    b.Property<Guid>("CursoId")
                        .HasColumnType("RAW(16)");

                    b.Property<Guid>("VideoId")
                        .HasColumnType("RAW(16)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DT_CRIACAO");

                    b.Property<Guid>("Id")
                        .HasColumnType("RAW(16)");

                    b.HasKey("CursoId", "VideoId")
                        .HasName("ID_CURSO_VIDEO");

                    b.HasIndex("VideoId");

                    b.ToTable("TB_CURSO_VIDEO", (string)null);
                });

            modelBuilder.Entity("FinanceFlix.Domain.Entities.Trilha", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("Trilhas");
                });

            modelBuilder.Entity("FinanceFlix.API.Entities.Curso", b =>
                {
                    b.HasOne("FinanceFlix.API.Entities.Categoria", "Categoria")
                        .WithMany("Cursos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("FinanceFlix.Domain.Entities.CursoVideo", b =>
                {
                    b.HasOne("FinanceFlix.API.Entities.Curso", "Curso")
                        .WithMany("CursosVideos")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinanceFlix.API.Entities.Video", "Video")
                        .WithMany("CursosVideos")
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("FinanceFlix.API.Entities.Categoria", b =>
                {
                    b.Navigation("Cursos");
                });

            modelBuilder.Entity("FinanceFlix.API.Entities.Curso", b =>
                {
                    b.Navigation("CursosVideos");
                });

            modelBuilder.Entity("FinanceFlix.API.Entities.Video", b =>
                {
                    b.Navigation("CursosVideos");
                });
#pragma warning restore 612, 618
        }
    }
}
