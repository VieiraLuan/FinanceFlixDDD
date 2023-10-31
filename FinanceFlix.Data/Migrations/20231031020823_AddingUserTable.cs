using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceFlix.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "TB_USUARIO");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "TB_USUARIO",
                newName: "NOME_USUARIO");

            migrationBuilder.AlterColumn<string>(
                name: "NOME_USUARIO",
                table: "TB_USUARIO",
                type: "NVARCHAR2(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DT_CRIACAO",
                table: "TB_USUARIO",
                type: "TIMESTAMP(7)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DT_ULTIMA_MODIFICACAO",
                table: "TB_USUARIO",
                type: "TIMESTAMP(7)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EMAIL_USUARIO",
                table: "TB_USUARIO",
                type: "NVARCHAR2(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FOTO_USUARIO",
                table: "TB_USUARIO",
                type: "NVARCHAR2(80)",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SENHA_USUARIO",
                table: "TB_USUARIO",
                type: "NVARCHAR2(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TIPO_USUARIO",
                table: "TB_USUARIO",
                type: "NVARCHAR2(80)",
                maxLength: 80,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "ID_USUARIO",
                table: "TB_USUARIO",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "ID_USUARIO",
                table: "TB_USUARIO");

            migrationBuilder.DropColumn(
                name: "DT_CRIACAO",
                table: "TB_USUARIO");

            migrationBuilder.DropColumn(
                name: "DT_ULTIMA_MODIFICACAO",
                table: "TB_USUARIO");

            migrationBuilder.DropColumn(
                name: "EMAIL_USUARIO",
                table: "TB_USUARIO");

            migrationBuilder.DropColumn(
                name: "FOTO_USUARIO",
                table: "TB_USUARIO");

            migrationBuilder.DropColumn(
                name: "SENHA_USUARIO",
                table: "TB_USUARIO");

            migrationBuilder.DropColumn(
                name: "TIPO_USUARIO",
                table: "TB_USUARIO");

            migrationBuilder.RenameTable(
                name: "TB_USUARIO",
                newName: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "NOME_USUARIO",
                table: "Usuarios",
                newName: "Nome");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Usuarios",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(80)",
                oldMaxLength: 80);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");
        }
    }
}
