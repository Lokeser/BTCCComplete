using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancaTCC.Migrations
{
    /// <inheritdoc />
    public partial class initial6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MembrosExternos_Bancas_BancaId",
                table: "MembrosExternos");

            migrationBuilder.DropForeignKey(
                name: "FK_OrientadoresIndicados_Professores_ProfessorId",
                table: "OrientadoresIndicados");

            migrationBuilder.DropForeignKey(
                name: "FK_OrientadoresIndicados_Trabalhos_TrabalhoId1",
                table: "OrientadoresIndicados");

            migrationBuilder.DropForeignKey(
                name: "FK_Trabalhos_Autores_AutorId",
                table: "Trabalhos");

            migrationBuilder.DropIndex(
                name: "IX_Trabalhos_AutorId",
                table: "Trabalhos");

            migrationBuilder.DropIndex(
                name: "IX_OrientadoresIndicados_ProfessorId",
                table: "OrientadoresIndicados");

            migrationBuilder.DropIndex(
                name: "IX_OrientadoresIndicados_TrabalhoId1",
                table: "OrientadoresIndicados");

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "Trabalhos");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "OrientadoresIndicados");

            migrationBuilder.DropColumn(
                name: "TrabalhoId",
                table: "OrientadoresIndicados");

            migrationBuilder.DropColumn(
                name: "TrabalhoId1",
                table: "OrientadoresIndicados");

            migrationBuilder.AlterColumn<int>(
                name: "BancaId",
                table: "MembrosExternos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MembrosExternos_Bancas_BancaId",
                table: "MembrosExternos",
                column: "BancaId",
                principalTable: "Bancas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MembrosExternos_Bancas_BancaId",
                table: "MembrosExternos");

            migrationBuilder.AddColumn<int>(
                name: "AutorId",
                table: "Trabalhos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfessorId",
                table: "OrientadoresIndicados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrabalhoId",
                table: "OrientadoresIndicados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "TrabalhoId1",
                table: "OrientadoresIndicados",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<int>(
                name: "BancaId",
                table: "MembrosExternos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trabalhos_AutorId",
                table: "Trabalhos",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrientadoresIndicados_ProfessorId",
                table: "OrientadoresIndicados",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrientadoresIndicados_TrabalhoId1",
                table: "OrientadoresIndicados",
                column: "TrabalhoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MembrosExternos_Bancas_BancaId",
                table: "MembrosExternos",
                column: "BancaId",
                principalTable: "Bancas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrientadoresIndicados_Professores_ProfessorId",
                table: "OrientadoresIndicados",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrientadoresIndicados_Trabalhos_TrabalhoId1",
                table: "OrientadoresIndicados",
                column: "TrabalhoId1",
                principalTable: "Trabalhos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trabalhos_Autores_AutorId",
                table: "Trabalhos",
                column: "AutorId",
                principalTable: "Autores",
                principalColumn: "Id");
        }
    }
}
