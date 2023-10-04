using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceFlix.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingRelationCursoCategoriaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_CURSO_TB_CATEGORIA_Id",
                table: "TB_CURSO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CURSO_CategoriaId",
                table: "TB_CURSO",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CURSO_TB_CATEGORIA_CategoriaId",
                table: "TB_CURSO",
                column: "CategoriaId",
                principalTable: "TB_CATEGORIA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_CURSO_TB_CATEGORIA_CategoriaId",
                table: "TB_CURSO");

            migrationBuilder.DropIndex(
                name: "IX_TB_CURSO_CategoriaId",
                table: "TB_CURSO");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CURSO_TB_CATEGORIA_Id",
                table: "TB_CURSO",
                column: "Id",
                principalTable: "TB_CATEGORIA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
