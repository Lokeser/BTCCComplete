using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancaTCC.Migrations
{
    /// <inheritdoc />
    public partial class initial9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Bancas_BancaId",
                table: "Comentario");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentario_Professores_ProfessorId",
                table: "Comentario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario");

            migrationBuilder.RenameTable(
                name: "Comentario",
                newName: "Comentarios");

            migrationBuilder.RenameIndex(
                name: "IX_Comentario_ProfessorId",
                table: "Comentarios",
                newName: "IX_Comentarios_ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentario_BancaId",
                table: "Comentarios",
                newName: "IX_Comentarios_BancaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comentarios",
                table: "Comentarios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Bancas_BancaId",
                table: "Comentarios",
                column: "BancaId",
                principalTable: "Bancas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Professores_ProfessorId",
                table: "Comentarios",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Bancas_BancaId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Professores_ProfessorId",
                table: "Comentarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comentarios",
                table: "Comentarios");

            migrationBuilder.RenameTable(
                name: "Comentarios",
                newName: "Comentario");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_ProfessorId",
                table: "Comentario",
                newName: "IX_Comentario_ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_BancaId",
                table: "Comentario",
                newName: "IX_Comentario_BancaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comentario",
                table: "Comentario",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Bancas_BancaId",
                table: "Comentario",
                column: "BancaId",
                principalTable: "Bancas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentario_Professores_ProfessorId",
                table: "Comentario",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
