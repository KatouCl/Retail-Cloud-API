using Microsoft.EntityFrameworkCore.Migrations;

namespace RetailCloud.Infrastracture.Migrations
{
    public partial class DeleteFieldInnFromTableEnterprises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inn",
                table: "Enterprises");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Inn",
                table: "Enterprises",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
