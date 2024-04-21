using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class correcionIdC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticuloComentario_Comentarios_ComentarioId",
                table: "ArticuloComentario");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Comentarios",
                newName: "IdC");

            migrationBuilder.RenameColumn(
                name: "ComentarioId",
                table: "ArticuloComentario",
                newName: "ComentarioIdC");

            migrationBuilder.RenameIndex(
                name: "IX_ArticuloComentario_ComentarioId",
                table: "ArticuloComentario",
                newName: "IX_ArticuloComentario_ComentarioIdC");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticuloComentario_Comentarios_ComentarioIdC",
                table: "ArticuloComentario",
                column: "ComentarioIdC",
                principalTable: "Comentarios",
                principalColumn: "IdC",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticuloComentario_Comentarios_ComentarioIdC",
                table: "ArticuloComentario");

            migrationBuilder.RenameColumn(
                name: "IdC",
                table: "Comentarios",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ComentarioIdC",
                table: "ArticuloComentario",
                newName: "ComentarioId");

            migrationBuilder.RenameIndex(
                name: "IX_ArticuloComentario_ComentarioIdC",
                table: "ArticuloComentario",
                newName: "IX_ArticuloComentario_ComentarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticuloComentario_Comentarios_ComentarioId",
                table: "ArticuloComentario",
                column: "ComentarioId",
                principalTable: "Comentarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
