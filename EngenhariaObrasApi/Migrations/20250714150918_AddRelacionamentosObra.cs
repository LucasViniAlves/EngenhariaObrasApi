using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EngenhariaObrasApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRelacionamentosObra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Responsavel",
                table: "Obras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Obras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "BDIs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdministracaoCentral = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    AdministracaoLocal = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    DespesasIndiretas = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    DespesaFinanceira = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    PosObras = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Risco = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Impostos = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    MargemLucro = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Seguro = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ReservaTecnica = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    ObraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BDIs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BDIs_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustosAdicionais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ObraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustosAdicionais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustosAdicionais_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaoDeObras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Profissional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HorasTrabalhadas = table.Column<int>(type: "int", nullable: false),
                    ObraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaoDeObras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaoDeObras_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materiais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ObraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materiais_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BDIs_ObraId",
                table: "BDIs",
                column: "ObraId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustosAdicionais_ObraId",
                table: "CustosAdicionais",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_MaoDeObras_ObraId",
                table: "MaoDeObras",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_Materiais_ObraId",
                table: "Materiais",
                column: "ObraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BDIs");

            migrationBuilder.DropTable(
                name: "CustosAdicionais");

            migrationBuilder.DropTable(
                name: "MaoDeObras");

            migrationBuilder.DropTable(
                name: "Materiais");

            migrationBuilder.AlterColumn<string>(
                name: "Responsavel",
                table: "Obras",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Obras",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
