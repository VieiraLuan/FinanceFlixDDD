using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceFlix.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatingTablesAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vizualizacoes",
                table: "TB_VIDEO",
                newName: "VIZUALIZACOES");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VIZUALIZACOES",
                table: "TB_VIDEO",
                newName: "Vizualizacoes");
        }
    }
}
