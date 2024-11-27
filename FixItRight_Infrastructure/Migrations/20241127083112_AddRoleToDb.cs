using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FixItRight_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a0bf18ce-48d8-4f97-820e-97b5af1974c8", null, "Admin", "ADMIN" },
                    { "b37d904e-16fb-4cda-8c3b-6f7f15f5819d", null, "Customer", "CUSTOMER" },
                    { "bee3179d-722c-404b-95c7-d3ae5c260d40", null, "Mechanist", "MECHANIST" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0bf18ce-48d8-4f97-820e-97b5af1974c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b37d904e-16fb-4cda-8c3b-6f7f15f5819d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bee3179d-722c-404b-95c7-d3ae5c260d40");
        }
    }
}
