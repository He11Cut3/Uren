using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hells_Tire.Migrations
{
    public partial class Initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "HellsTireProductSlug",
                table: "HellsTireProducts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HellsTireProductSlug",
                table: "HellsTireProducts");
        }
    }
}
