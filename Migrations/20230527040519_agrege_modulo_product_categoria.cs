using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemasWeb01.Migrations
{
    public partial class agrege_modulo_product_categoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoriasdbcontex",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreCategoria = table.Column<string>(type: "TEXT", nullable: false),
                    DescripcionCategoria = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoriasdbcontex", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Productosdbcontex",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreProducto = table.Column<string>(type: "TEXT", nullable: false),
                    DescripcionProducto = table.Column<string>(type: "TEXT", nullable: false),
                    PrecioProducto = table.Column<decimal>(type: "TEXT", nullable: false),
                    ImagenProducto = table.Column<string>(type: "TEXT", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productosdbcontex", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_Productosdbcontex_Categoriasdbcontex_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoriasdbcontex",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productosdbcontex_CategoriaId",
                table: "Productosdbcontex",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productosdbcontex");

            migrationBuilder.DropTable(
                name: "Categoriasdbcontex");
        }
    }
}
