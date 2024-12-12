using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancaTCC.Migrations
{
    /// <inheritdoc />
    public partial class initial16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrabalhoId",
                table: "Bancas",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrabalhoId",
                table: "Bancas");
        }
    }
}
