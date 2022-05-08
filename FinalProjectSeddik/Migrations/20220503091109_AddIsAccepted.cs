using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectSeddik.Migrations
{
    public partial class AddIsAccepted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "ComptitveRegistration",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "ComptitveRegistration");
        }
    }
}
