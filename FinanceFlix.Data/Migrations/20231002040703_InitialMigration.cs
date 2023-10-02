using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceFlix.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CATEGORIA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    NOME_CATEGORIA = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    DESC_CATEGORIA = table.Column<string>(type: "NVARCHAR2(120)", maxLength: 120, nullable: false),
                    DT_CRIACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_CATEGORIA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_VIDEO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    NOME_VIDEO = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    DESC_VIDEO = table.Column<string>(type: "NVARCHAR2(120)", maxLength: 120, nullable: false),
                    URL_VIDEO = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    DURACAO_SEGUNDOS = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FILE_PATH = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    DT_CRIACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_VIDEO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trilhas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trilhas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_CURSO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    NOME_CURSO = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    DESC_CURSO = table.Column<string>(type: "NVARCHAR2(120)", maxLength: 120, nullable: false),
                    URL_IMAGEM = table.Column<byte[]>(type: "RAW(2000)", nullable: true),
                    CategoriaId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    DT_CRIACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_CURSO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_CURSO_TB_CATEGORIA_Id",
                        column: x => x.Id,
                        principalTable: "TB_CATEGORIA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_CURSO_VIDEO",
                columns: table => new
                {
                    CursoId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    VideoId = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    DT_CRIACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_CURSO_VIDEO", x => new { x.CursoId, x.VideoId });
                    table.ForeignKey(
                        name: "FK_TB_CURSO_VIDEO_TB_CURSO_CursoId",
                        column: x => x.CursoId,
                        principalTable: "TB_CURSO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_CURSO_VIDEO_TB_VIDEO_VideoId",
                        column: x => x.VideoId,
                        principalTable: "TB_VIDEO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_CURSO_VIDEO_VideoId",
                table: "TB_CURSO_VIDEO",
                column: "VideoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CURSO_VIDEO");

            migrationBuilder.DropTable(
                name: "Trilhas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "TB_CURSO");

            migrationBuilder.DropTable(
                name: "TB_VIDEO");

            migrationBuilder.DropTable(
                name: "TB_CATEGORIA");
        }
    }
}
