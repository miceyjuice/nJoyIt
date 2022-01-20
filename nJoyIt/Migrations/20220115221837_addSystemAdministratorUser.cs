using Microsoft.EntityFrameworkCore.Migrations;

namespace nJoyIt.Migrations
{
    public partial class addSystemAdministratorUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "UserName", "NormalizedUserName", "EmailConfirmed", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnabled", "AccessFailedCount", "PasswordHash" },
                values: new object[] { "4c360889-660c-4cb6-bf78-d2cb9353289d", "Admin", "ADMIN", true, true, false, false, 0, "AQAAAAEAACcQAAAAEMvzk20PQYOPM4nxGs+LWxUDTZQWISoNRaiBMgRXf/M0SZIC29FGC6EQ5LxTUP5jPQ==" }
            );
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "4c360889-660c-4cb6-bf78-d2cb9353289d", "56a856cf-54d7-4f94-814b-7331f5c9b975" }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4c360889-660c-4cb6-bf78-d2cb9353289d"
            );
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumn: "UserId",
                keyValue: "4c360889-660c-4cb6-bf78-d2cb9353289d"
            );
        }
    }
}
