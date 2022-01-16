using Microsoft.EntityFrameworkCore.Migrations;

namespace nJoyIt.Migrations
{
    public partial class addAdminRoleGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] {"Id", "Name", "NormalizedName"},
                values: new object[] {"56a856cf-54d7-4f94-814b-7331f5c9b975", "Admin", "ADMINISTRATOR"}
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56a856cf-54d7-4f94-814b-7331f5c9b975"
            );
        }
    }
}
