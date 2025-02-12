using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixItRight_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddResetPasswordToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordResetToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PasswordResetTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "34e5bee4-75cb-423b-b8a3-58e5d0175989",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "PasswordResetToken", "PasswordResetTokenExpiryTime", "SecurityStamp" },
                values: new object[] { "911a83ed-4850-4e33-91c6-8da2edc26b16", new DateTime(2025, 2, 12, 14, 14, 30, 184, DateTimeKind.Local).AddTicks(243), "AQAAAAIAAYagAAAAEAOA3Bu9qQw3s5q4xW1DmuuA87ToaAZsiAPNX//lJtWt1jopTHYGy6apXqW/KIJQ+Q==", null, null, "3605eff2-3483-444d-8492-e9a430f0982a" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("23814aee-13c1-41e4-a80d-bb8882eb00b2"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 12, 14, 14, 30, 241, DateTimeKind.Local).AddTicks(5188));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("3d32363b-dfa9-49ee-a6ac-8d3e7983294b"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 12, 14, 14, 30, 241, DateTimeKind.Local).AddTicks(5195));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("85aa164a-a52c-4af3-95fd-29890f8df531"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 12, 14, 14, 30, 241, DateTimeKind.Local).AddTicks(5169));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("8f19e546-a41d-488a-85df-558af0caf391"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 12, 14, 14, 30, 241, DateTimeKind.Local).AddTicks(5184));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("a838bccb-7786-462f-b4b0-018b9ce03560"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 12, 14, 14, 30, 241, DateTimeKind.Local).AddTicks(5182));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("c3266aac-f1b7-4d4a-afb1-8bb2dae6bc8f"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 12, 14, 14, 30, 241, DateTimeKind.Local).AddTicks(5177));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("c9ff969c-4f3a-4c6c-877f-dd36f07189ed"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 12, 14, 14, 30, 241, DateTimeKind.Local).AddTicks(5180));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("ccf59cf8-77d1-4f1e-82cc-42ee70dc0362"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 12, 14, 14, 30, 241, DateTimeKind.Local).AddTicks(5186));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("cd7bdc7f-6e90-46fc-a9a3-f5fab0169851"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 12, 14, 14, 30, 241, DateTimeKind.Local).AddTicks(5137));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("e21baed2-ac4d-4d91-af85-370f8ae5dd6c"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 12, 14, 14, 30, 241, DateTimeKind.Local).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("f5c248ee-d9e6-44d3-9b16-117ceb616b9e"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 12, 14, 14, 30, 241, DateTimeKind.Local).AddTicks(5193));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordResetToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PasswordResetTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "34e5bee4-75cb-423b-b8a3-58e5d0175989",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5533a3f5-c61b-41d2-a1ef-105355c2621d", new DateTime(2025, 2, 7, 21, 25, 37, 135, DateTimeKind.Local).AddTicks(9680), "AQAAAAIAAYagAAAAEBBL4J7+BlkcrCLXeXA+qguVmyictCLQnWb6ZjbK0nPoI3MY8ZJR50J4Y5h6kfoOIg==", "79e37545-d16a-412d-ae35-05f55c8b5b60" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("23814aee-13c1-41e4-a80d-bb8882eb00b2"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 25, 37, 195, DateTimeKind.Local).AddTicks(6198));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("3d32363b-dfa9-49ee-a6ac-8d3e7983294b"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 25, 37, 195, DateTimeKind.Local).AddTicks(6205));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("85aa164a-a52c-4af3-95fd-29890f8df531"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 25, 37, 195, DateTimeKind.Local).AddTicks(6184));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("8f19e546-a41d-488a-85df-558af0caf391"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 25, 37, 195, DateTimeKind.Local).AddTicks(6193));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("a838bccb-7786-462f-b4b0-018b9ce03560"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 25, 37, 195, DateTimeKind.Local).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("c3266aac-f1b7-4d4a-afb1-8bb2dae6bc8f"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 25, 37, 195, DateTimeKind.Local).AddTicks(6186));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("c9ff969c-4f3a-4c6c-877f-dd36f07189ed"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 25, 37, 195, DateTimeKind.Local).AddTicks(6189));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("ccf59cf8-77d1-4f1e-82cc-42ee70dc0362"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 25, 37, 195, DateTimeKind.Local).AddTicks(6195));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("cd7bdc7f-6e90-46fc-a9a3-f5fab0169851"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 25, 37, 195, DateTimeKind.Local).AddTicks(6151));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("e21baed2-ac4d-4d91-af85-370f8ae5dd6c"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 25, 37, 195, DateTimeKind.Local).AddTicks(6201));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("f5c248ee-d9e6-44d3-9b16-117ceb616b9e"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 7, 21, 25, 37, 195, DateTimeKind.Local).AddTicks(6203));
        }
    }
}
