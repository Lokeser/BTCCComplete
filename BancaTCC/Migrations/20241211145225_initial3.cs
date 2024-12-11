using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancaTCC.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrabalhoId",
                table: "Trabalhos",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "AutorId",
                table: "Trabalhos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bancas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraFim = table.Column<TimeSpan>(type: "time", nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrabalhoId = table.Column<int>(type: "int", nullable: false),
                    TrabalhoId1 = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bancas_Trabalhos_TrabalhoId1",
                        column: x => x.TrabalhoId1,
                        principalTable: "Trabalhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargaHoraria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Matricula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MembrosExternos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BancaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembrosExternos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MembrosExternos_Bancas_BancaId",
                        column: x => x.BancaId,
                        principalTable: "Bancas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Matricula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Autores_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrientadoresIndicados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdemPreferencia = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    TrabalhoId = table.Column<int>(type: "int", nullable: false),
                    TrabalhoId1 = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrientadoresIndicados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrientadoresIndicados_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrientadoresIndicados_Trabalhos_TrabalhoId1",
                        column: x => x.TrabalhoId1,
                        principalTable: "Trabalhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trabalhos_AutorId",
                table: "Trabalhos",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Autores_CursoId",
                table: "Autores",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Bancas_TrabalhoId1",
                table: "Bancas",
                column: "TrabalhoId1");

            migrationBuilder.CreateIndex(
                name: "IX_MembrosExternos_BancaId",
                table: "MembrosExternos",
                column: "BancaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrientadoresIndicados_ProfessorId",
                table: "OrientadoresIndicados",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrientadoresIndicados_TrabalhoId1",
                table: "OrientadoresIndicados",
                column: "TrabalhoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Trabalhos_Autores_AutorId",
                table: "Trabalhos",
                column: "AutorId",
                principalTable: "Autores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trabalhos_Autores_AutorId",
                table: "Trabalhos");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "MembrosExternos");

            migrationBuilder.DropTable(
                name: "OrientadoresIndicados");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Bancas");

            migrationBuilder.DropTable(
                name: "Professores");

            migrationBuilder.DropIndex(
                name: "IX_Trabalhos_AutorId",
                table: "Trabalhos");

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "Trabalhos");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Trabalhos",
                newName: "TrabalhoId");
        }
    }
}
