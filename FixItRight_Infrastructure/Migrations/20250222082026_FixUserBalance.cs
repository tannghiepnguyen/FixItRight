using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixItRight_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixUserBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Bookings_BookingId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_BookingId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Transactions");

            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "AspNetUsers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "34e5bee4-75cb-423b-b8a3-58e5d0175989",
                columns: new[] { "Balance", "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { 0.0, "c5ec63e3-7ed9-416f-9b4f-01076a9978b3", new DateTime(2025, 2, 22, 15, 20, 25, 987, DateTimeKind.Local).AddTicks(4840), "AQAAAAIAAYagAAAAEPSwcaGUHIHiSDsxlOsiVXigViHd3Wtm0Jaz9FKZb39GUObqZOqB1rIS1v6+BMDSxg==", "419ed93a-a02a-4595-9aa2-79be41bf89fe" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "BookingId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "34e5bee4-75cb-423b-b8a3-58e5d0175989",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "911a83ed-4850-4e33-91c6-8da2edc26b16", new DateTime(2025, 2, 12, 14, 14, 30, 184, DateTimeKind.Local).AddTicks(243), "AQAAAAIAAYagAAAAEAOA3Bu9qQw3s5q4xW1DmuuA87ToaAZsiAPNX//lJtWt1jopTHYGy6apXqW/KIJQ+Q==", "3605eff2-3483-444d-8492-e9a430f0982a" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BookingId",
                table: "Transactions",
                column: "BookingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Bookings_BookingId",
                table: "Transactions",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id");
        }
    }
}
