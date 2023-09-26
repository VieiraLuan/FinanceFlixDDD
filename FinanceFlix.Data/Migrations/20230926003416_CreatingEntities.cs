using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceFlix.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatingEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CATEGORIA",
                columns: table => new
                {
                    ID_CATEGORIA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME_CATEGORIA = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    DESC_CATEGORIA = table.Column<string>(type: "NVARCHAR2(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CATEGORIA", x => x.ID_CATEGORIA);
                });

            migrationBuilder.CreateTable(
                name: "TB_TRILHA",
                columns: table => new
                {
                    ID_TRILHA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME_TRILHA = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    DESC_TRILHA = table.Column<string>(type: "NVARCHAR2(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TRILHA", x => x.ID_TRILHA);
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
                    PATH_VIDEO = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VIDEO", x => x.ID_VIDEO);
                });

            migrationBuilder.CreateTable(
                name: "TB_CURSO",
                columns: table => new
                {
                    ID_CURSO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME_CURSO = table.Column<string>(type: "NVARCHAR2(80)", maxLength: 80, nullable: false),
                    DESC_CURSO = table.Column<string>(type: "NVARCHAR2(120)", maxLength: 120, nullable: false),
                    IMG_CURSO = table.Column<byte[]>(type: "RAW(2000)", nullable: true),
                    CategoriaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CURSO", x => x.ID_CURSO);
                    table.ForeignKey(
                        name: "FK_TB_CURSO_TB_CATEGORIA_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "TB_CATEGORIA",
                        principalColumn: "ID_CATEGORIA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_CURSO_TRILHA",
                columns: table => new
                {
                    CursoVideoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CursoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TrilhaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CURSO_TRILHA", x => x.CursoVideoId);
                    table.ForeignKey(
                        name: "FK_TB_CURSO_TRILHA_TB_CURSO_CursoId",
                        column: x => x.CursoId,
                        principalTable: "TB_CURSO",
                        principalColumn: "ID_CURSO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_CURSO_TRILHA_TB_TRILHA_TrilhaId",
                        column: x => x.TrilhaId,
                        principalTable: "TB_TRILHA",
                        principalColumn: "ID_TRILHA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_CURSO_VIDEO",
                columns: table => new
                {
                    CursoVideoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    CursoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    VideoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CURSO_VIDEO", x => x.CursoVideoId);
                    table.ForeignKey(
                        name: "FK_TB_CURSO_VIDEO_TB_CURSO_CursoId",
                        column: x => x.CursoId,
                        principalTable: "TB_CURSO",
                        principalColumn: "ID_CURSO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_CURSO_VIDEO_TB_VIDEO_VideoId",
                        column: x => x.VideoId,
                        principalTable: "TB_VIDEO",
                        principalColumn: "ID_VIDEO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_CURSO_CategoriaId",
                table: "TB_CURSO",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CURSO_TRILHA_CursoId",
                table: "TB_CURSO_TRILHA",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CURSO_TRILHA_TrilhaId",
                table: "TB_CURSO_TRILHA",
                column: "TrilhaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CURSO_VIDEO_CursoId",
                table: "TB_CURSO_VIDEO",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CURSO_VIDEO_VideoId",
                table: "TB_CURSO_VIDEO",
                column: "VideoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CURSO_TRILHA");

            migrationBuilder.DropTable(
                name: "TB_CURSO_VIDEO");

            migrationBuilder.DropTable(
                name: "TB_TRILHA");

            migrationBuilder.DropTable(
                name: "TB_CURSO");

            migrationBuilder.DropTable(
                name: "TB_VIDEO");

            migrationBuilder.DropTable(
                name: "TB_CATEGORIA");
        }
    }
}
