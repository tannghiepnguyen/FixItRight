using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixItRight_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updatetransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OrderCode",
                table: "Transactions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "34e5bee4-75cb-423b-b8a3-58e5d0175989",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ad06cfe-b883-4216-8b78-3696b6a99b41", new DateTime(2025, 3, 5, 15, 25, 44, 547, DateTimeKind.Local).AddTicks(5398), "AQAAAAIAAYagAAAAEDeA9lX8pwWmWNtbAmqs2eVJSMqDUnqqfA+3xpciLZ+7mZ4Smw/8hR/FVZSjeKeWbw==", "dec25122-8c95-4ef4-b438-7fdc7bc38b1e" });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("23814aee-13c1-41e4-a80d-bb8882eb00b2"),
                column: "CreatedAt",
                value: new DateTime(2025, 3, 5, 15, 25, 44, 602, DateTimeKind.Local).AddTicks(3739));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("3d32363b-dfa9-49ee-a6ac-8d3e7983294b"),
                column: "CreatedAt",
                value: new DateTime(2025, 3, 5, 15, 25, 44, 602, DateTimeKind.Local).AddTicks(3756));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("85aa164a-a52c-4af3-95fd-29890f8df531"),
                column: "CreatedAt",
                value: new DateTime(2025, 3, 5, 15, 25, 44, 602, DateTimeKind.Local).AddTicks(3651));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("8f19e546-a41d-488a-85df-558af0caf391"),
                column: "CreatedAt",
                value: new DateTime(2025, 3, 5, 15, 25, 44, 602, DateTimeKind.Local).AddTicks(3734));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("a838bccb-7786-462f-b4b0-018b9ce03560"),
                column: "CreatedAt",
                value: new DateTime(2025, 3, 5, 15, 25, 44, 602, DateTimeKind.Local).AddTicks(3726));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("c3266aac-f1b7-4d4a-afb1-8bb2dae6bc8f"),
                column: "CreatedAt",
                value: new DateTime(2025, 3, 5, 15, 25, 44, 602, DateTimeKind.Local).AddTicks(3654));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("c9ff969c-4f3a-4c6c-877f-dd36f07189ed"),
                column: "CreatedAt",
                value: new DateTime(2025, 3, 5, 15, 25, 44, 602, DateTimeKind.Local).AddTicks(3656));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("ccf59cf8-77d1-4f1e-82cc-42ee70dc0362"),
                column: "CreatedAt",
                value: new DateTime(2025, 3, 5, 15, 25, 44, 602, DateTimeKind.Local).AddTicks(3736));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("cd7bdc7f-6e90-46fc-a9a3-f5fab0169851"),
                column: "CreatedAt",
                value: new DateTime(2025, 3, 5, 15, 25, 44, 602, DateTimeKind.Local).AddTicks(3619));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("e21baed2-ac4d-4d91-af85-370f8ae5dd6c"),
                column: "CreatedAt",
                value: new DateTime(2025, 3, 5, 15, 25, 44, 602, DateTimeKind.Local).AddTicks(3745));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("f5c248ee-d9e6-44d3-9b16-117ceb616b9e"),
                column: "CreatedAt",
                value: new DateTime(2025, 3, 5, 15, 25, 44, 602, DateTimeKind.Local).AddTicks(3754));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderCode",
                table: "Transactions");

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
    }
}
