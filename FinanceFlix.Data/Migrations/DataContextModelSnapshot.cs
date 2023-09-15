﻿// <auto-generated />
using System;
using FinanceFlix.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace FinanceFlix.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("RAW(16)")
                        .HasColumnName("ID_CATEGORIA");

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

                    b.HasKey("Id");

                    b.ToTable("TB_CATEGORIA");
                });

            modelBuilder.Entity("FinanceFlix.API.Entities.Curso", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)")
                        .HasColumnName("ID_CURSO");

                    b.Property<Guid?>("CategoriaId")
                        .HasColumnType("RAW(16)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("NVARCHAR2(120)")
                        .HasColumnName("DESC_CURSO");

                    b.Property<byte[]>("ImagemUrl")
                        .IsRequired()
                        .HasColumnType("RAW(2000)")
                        .HasColumnName("IMG_CURSO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("NVARCHAR2(80)")
                        .HasColumnName("NOME_CURSO");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("TB_CURSO");
                });

            modelBuilder.Entity("FinanceFlix.API.Entities.Video", b =>
                {
                    b.Property<int>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("ID_VIDEO");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Guid"));

                    b.Property<Guid?>("CursoId")
                        .HasColumnType("RAW(16)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("NVARCHAR2(120)")
                        .HasColumnName("DESC_VIDEO");

                    b.Property<int>("DuracaoSegundos")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("DURACAO_VIDEO");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)")
                        .HasColumnName("PATH_VIDEO");

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

                    b.HasKey("Guid");

                    b.HasIndex("CursoId");

                    b.ToTable("TB_VIDEO");
                });

            modelBuilder.Entity("FinanceFlix.API.Entities.Curso", b =>
                {
                    b.HasOne("FinanceFlix.API.Entities.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("FinanceFlix.API.Entities.Video", b =>
                {
                    b.HasOne("FinanceFlix.API.Entities.Curso", "Curso")
                        .WithMany("Videos")
                        .HasForeignKey("CursoId");

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("FinanceFlix.API.Entities.Curso", b =>
                {
                    b.Navigation("Videos");
                });
#pragma warning restore 612, 618
        }
    }
}
