using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class tablaLikesCorrecto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticuloLike_Like_LikeIdL",
                table: "ArticuloLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Like",
                table: "Like");

            migrationBuilder.RenameTable(
                name: "Like",
                newName: "Likes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "IdL");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticuloLike_Likes_LikeIdL",
                table: "ArticuloLike",
                column: "LikeIdL",
                principalTable: "Likes",
                principalColumn: "IdL",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticuloLike_Likes_LikeIdL",
                table: "ArticuloLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.RenameTable(
                name: "Likes",
                newName: "Like");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Like",
                table: "Like",
                column: "IdL");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticuloLike_Like_LikeIdL",
                table: "ArticuloLike",
                column: "LikeIdL",
                principalTable: "Like",
                principalColumn: "IdL",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
