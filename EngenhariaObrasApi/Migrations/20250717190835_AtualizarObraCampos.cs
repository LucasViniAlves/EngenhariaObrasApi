using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EngenhariaObrasApi.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarObraCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentidadeCliente",
                table: "Obras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeCliente",
                table: "Obras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "areaTotal",
                table: "Obras",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "emailCliente",
                table: "Obras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "engenheiro",
                table: "Obras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "faseAtual",
                table: "Obras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "local",
                table: "Obras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "observacoes",
                table: "Obras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tipoObra",
                table: "Obras",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentidadeCliente",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "NomeCliente",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "areaTotal",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "emailCliente",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "engenheiro",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "faseAtual",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "local",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "observacoes",
                table: "Obras");

            migrationBuilder.DropColumn(
                name: "tipoObra",
                table: "Obras");
        }
    }
}
