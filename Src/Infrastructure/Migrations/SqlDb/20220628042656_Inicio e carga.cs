using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations.SqlDb
{
    public partial class Inicioecarga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProdutoGenero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoGenero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoTipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoTipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 120, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(1000)", maxLength: 185, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    ProdutoTipoId = table.Column<int>(type: "int", nullable: false),
                    ProdutoGeneroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_ProdutoGenero_ProdutoGeneroId",
                        column: x => x.ProdutoGeneroId,
                        principalTable: "ProdutoGenero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Produto_ProdutoTipo_ProdutoTipoId",
                        column: x => x.ProdutoTipoId,
                        principalTable: "ProdutoTipo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_ProdutoGeneroId",
                table: "Produto",
                column: "ProdutoGeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_ProdutoTipoId",
                table: "Produto",
                column: "ProdutoTipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "ProdutoGenero");

            migrationBuilder.DropTable(
                name: "ProdutoTipo");
        }
    }
}
