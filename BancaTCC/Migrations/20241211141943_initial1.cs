using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancaTCC.Migrations
{
    /// <inheritdoc />
    public partial class initial1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trabalhos",
                columns: table => new
                {
                    TrabalhoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrabalhoTema = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrabalhoArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrabalhoLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrabalhoGitLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabalhos", x => x.TrabalhoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trabalhos");
        }
    }
}
