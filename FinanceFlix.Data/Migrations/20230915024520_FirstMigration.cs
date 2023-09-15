using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceFlix.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CATEGORIA",
                columns: table => new
                {
                    ID_CATEGORIA = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    NOME_CATEGORIA = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    DESC_CATEGORIA = table.Column<string>(type: "NVARCHAR2(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CATEGORIA", x => x.ID_CATEGORIA);
                });

            migrationBuilder.CreateTable(
                name: "TB_CURSO",
                columns: table => new
                {
                    ID_CURSO = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    NOME_CURSO = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    DESC_CURSO = table.Column<string>(type: "NVARCHAR2(120)", maxLength: 120, nullable: false),
                    IMG_CURSO = table.Column<byte[]>(type: "RAW(2000)", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "RAW(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CURSO", x => x.ID_CURSO);
                    table.ForeignKey(
                        name: "FK_TB_CURSO_TB_CATEGORIA_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "TB_CATEGORIA",
                        principalColumn: "ID_CATEGORIA");
                });

            migrationBuilder.CreateTable(
                name: "TB_VIDEO",
                columns: table => new
                {
                    ID_VIDEO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME_VIDEO = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    DESC_VIDEO = table.Column<string>(type: "NVARCHAR2(120)", maxLength: 120, nullable: false),
                    URL_VIDEO = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    DURACAO_VIDEO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PATH_VIDEO = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    CursoId = table.Column<Guid>(type: "RAW(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VIDEO", x => x.ID_VIDEO);
                    table.ForeignKey(
                        name: "FK_TB_VIDEO_TB_CURSO_CursoId",
                        column: x => x.CursoId,
                        principalTable: "TB_CURSO",
                        principalColumn: "ID_CURSO");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_CURSO_CategoriaId",
                table: "TB_CURSO",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_VIDEO_CursoId",
                table: "TB_VIDEO",
                column: "CursoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_VIDEO");

            migrationBuilder.DropTable(
                name: "TB_CURSO");

            migrationBuilder.DropTable(
                name: "TB_CATEGORIA");
        }
    }
}
