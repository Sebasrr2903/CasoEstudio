using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class tablaLikes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    IdL = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.IdL);
                });

            migrationBuilder.CreateTable(
                name: "ArticuloLike",
                columns: table => new
                {
                    ArticuloId = table.Column<int>(type: "int", nullable: false),
                    LikeIdL = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticuloLike", x => new { x.ArticuloId, x.LikeIdL });
                    table.ForeignKey(
                        name: "FK_ArticuloLike_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticuloLike_Like_LikeIdL",
                        column: x => x.LikeIdL,
                        principalTable: "Like",
                        principalColumn: "IdL",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticuloLike_LikeIdL",
                table: "ArticuloLike",
                column: "LikeIdL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticuloLike");

            migrationBuilder.DropTable(
                name: "Like");
        }
    }
}
