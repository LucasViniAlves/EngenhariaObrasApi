using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EngenhariaObrasApi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMaterialObraFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materiais_Obras_ObraId",
                table: "Materiais");

            migrationBuilder.AlterColumn<int>(
                name: "ObraId",
                table: "Materiais",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Materiais_Obras_ObraId",
                table: "Materiais",
                column: "ObraId",
                principalTable: "Obras",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materiais_Obras_ObraId",
                table: "Materiais");

            migrationBuilder.AlterColumn<int>(
                name: "ObraId",
                table: "Materiais",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Materiais_Obras_ObraId",
                table: "Materiais",
                column: "ObraId",
                principalTable: "Obras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
