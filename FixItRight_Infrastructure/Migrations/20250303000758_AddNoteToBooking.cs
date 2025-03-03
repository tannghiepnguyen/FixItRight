using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixItRight_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNoteToBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "34e5bee4-75cb-423b-b8a3-58e5d0175989",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "183f8245-9da8-4edf-82c7-8ad18a1e453a", new DateTime(2025, 3, 3, 7, 7, 57, 664, DateTimeKind.Local).AddTicks(1954), "AQAAAAIAAYagAAAAEAL+sfu9hUBy4GnT7QW4HYi3j0bW+KqzMZJ8FUxnNLvRNFiBm2pyQkRNkBVvPPRskQ==", "75b5e7ea-e866-49e6-a5c8-4baaa9f51b3f" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("23814aee-13c1-41e4-a80d-bb8882eb00b2"),
                column: "CreatedAt",
                value: new DateTime(2025, 3, 3, 7, 7, 57, 722, DateTimeKind.Local).AddTicks(1783));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("3d32363b-dfa9-49ee-a6ac-8d3e7983294b"),
                column: "CreatedAt",
                value: new DateTime(2025, 3, 3, 7, 7, 57, 722, DateTimeKind.Local).AddTicks(1794));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("85aa164a-a52c-4af3-95fd-29890f8df531"),
                column: "CreatedAt",
                value: new DateTime(2025, 3, 3, 7, 7, 57, 722, DateTimeKind.Local).AddTicks(1765));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("8f19e546-a41d-488a-85df-558af0caf391"),
                column: "CreatedAt",
                value: new DateTime(2025, 3, 3, 7, 7, 57, 722, DateTimeKind.Local).AddTicks(1778));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("a838bccb-7786-462f-b4b0-018b9ce03560"),
                column: "CreatedAt",
                value: new DateTime(2025, 3, 3, 7, 7, 57, 722, DateTimeKind.Local).AddTicks(1776));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("c3266aac-f1b7-4d4a-afb1-8bb2dae6bc8f"),
                column: "CreatedAt",
                value: new DateTime(2025, 3, 3, 7, 7, 57, 722, DateTimeKind.Local).AddTicks(1771));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("c9ff969c-4f3a-4c6c-877f-dd36f07189ed"),
                column: "CreatedAt",
                value: new DateTime(2025, 3, 3, 7, 7, 57, 722, DateTimeKind.Local).AddTicks(1773));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("ccf59cf8-77d1-4f1e-82cc-42ee70dc0362"),
                column: "CreatedAt",
                value: new DateTime(2025, 3, 3, 7, 7, 57, 722, DateTimeKind.Local).AddTicks(1781));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("cd7bdc7f-6e90-46fc-a9a3-f5fab0169851"),
                column: "CreatedAt",
                value: new DateTime(2025, 3, 3, 7, 7, 57, 722, DateTimeKind.Local).AddTicks(1738));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("e21baed2-ac4d-4d91-af85-370f8ae5dd6c"),
                column: "CreatedAt",
                value: new DateTime(2025, 3, 3, 7, 7, 57, 722, DateTimeKind.Local).AddTicks(1786));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("f5c248ee-d9e6-44d3-9b16-117ceb616b9e"),
                column: "CreatedAt",
                value: new DateTime(2025, 3, 3, 7, 7, 57, 722, DateTimeKind.Local).AddTicks(1792));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "34e5bee4-75cb-423b-b8a3-58e5d0175989",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5ec63e3-7ed9-416f-9b4f-01076a9978b3", new DateTime(2025, 2, 22, 15, 20, 25, 987, DateTimeKind.Local).AddTicks(4840), "AQAAAAIAAYagAAAAEPSwcaGUHIHiSDsxlOsiVXigViHd3Wtm0Jaz9FKZb39GUObqZOqB1rIS1v6+BMDSxg==", "419ed93a-a02a-4595-9aa2-79be41bf89fe" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("23814aee-13c1-41e4-a80d-bb8882eb00b2"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 22, 15, 20, 26, 44, DateTimeKind.Local).AddTicks(8280));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("3d32363b-dfa9-49ee-a6ac-8d3e7983294b"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 22, 15, 20, 26, 44, DateTimeKind.Local).AddTicks(8288));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("85aa164a-a52c-4af3-95fd-29890f8df531"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 22, 15, 20, 26, 44, DateTimeKind.Local).AddTicks(8262));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("8f19e546-a41d-488a-85df-558af0caf391"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 22, 15, 20, 26, 44, DateTimeKind.Local).AddTicks(8275));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("a838bccb-7786-462f-b4b0-018b9ce03560"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 22, 15, 20, 26, 44, DateTimeKind.Local).AddTicks(8273));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("c3266aac-f1b7-4d4a-afb1-8bb2dae6bc8f"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 22, 15, 20, 26, 44, DateTimeKind.Local).AddTicks(8268));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("c9ff969c-4f3a-4c6c-877f-dd36f07189ed"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 22, 15, 20, 26, 44, DateTimeKind.Local).AddTicks(8271));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("ccf59cf8-77d1-4f1e-82cc-42ee70dc0362"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 22, 15, 20, 26, 44, DateTimeKind.Local).AddTicks(8278));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("cd7bdc7f-6e90-46fc-a9a3-f5fab0169851"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 22, 15, 20, 26, 44, DateTimeKind.Local).AddTicks(8235));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("e21baed2-ac4d-4d91-af85-370f8ae5dd6c"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 22, 15, 20, 26, 44, DateTimeKind.Local).AddTicks(8284));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("f5c248ee-d9e6-44d3-9b16-117ceb616b9e"),
                column: "CreatedAt",
                value: new DateTime(2025, 2, 22, 15, 20, 26, 44, DateTimeKind.Local).AddTicks(8286));
        }
    }
}
