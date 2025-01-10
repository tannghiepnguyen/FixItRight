using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixItRight_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyForBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "WorkingDate",
                table: "Bookings",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "WorkingTime",
                table: "Bookings",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("23814aee-13c1-41e4-a80d-bb8882eb00b2"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 13, 34, 41, 973, DateTimeKind.Local).AddTicks(8839));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("3d32363b-dfa9-49ee-a6ac-8d3e7983294b"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 13, 34, 41, 973, DateTimeKind.Local).AddTicks(8845));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("85aa164a-a52c-4af3-95fd-29890f8df531"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 13, 34, 41, 973, DateTimeKind.Local).AddTicks(8823));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("8f19e546-a41d-488a-85df-558af0caf391"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 13, 34, 41, 973, DateTimeKind.Local).AddTicks(8835));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("a838bccb-7786-462f-b4b0-018b9ce03560"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 13, 34, 41, 973, DateTimeKind.Local).AddTicks(8833));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("c3266aac-f1b7-4d4a-afb1-8bb2dae6bc8f"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 13, 34, 41, 973, DateTimeKind.Local).AddTicks(8828));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("c9ff969c-4f3a-4c6c-877f-dd36f07189ed"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 13, 34, 41, 973, DateTimeKind.Local).AddTicks(8831));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("ccf59cf8-77d1-4f1e-82cc-42ee70dc0362"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 13, 34, 41, 973, DateTimeKind.Local).AddTicks(8837));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("cd7bdc7f-6e90-46fc-a9a3-f5fab0169851"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 13, 34, 41, 973, DateTimeKind.Local).AddTicks(8809));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("e21baed2-ac4d-4d91-af85-370f8ae5dd6c"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 13, 34, 41, 973, DateTimeKind.Local).AddTicks(8841));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("f5c248ee-d9e6-44d3-9b16-117ceb616b9e"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 10, 13, 34, 41, 973, DateTimeKind.Local).AddTicks(8843));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "WorkingDate",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "WorkingTime",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("23814aee-13c1-41e4-a80d-bb8882eb00b2"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 9, 16, 25, 54, 103, DateTimeKind.Local).AddTicks(7768));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("3d32363b-dfa9-49ee-a6ac-8d3e7983294b"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 9, 16, 25, 54, 103, DateTimeKind.Local).AddTicks(7777));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("85aa164a-a52c-4af3-95fd-29890f8df531"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 9, 16, 25, 54, 103, DateTimeKind.Local).AddTicks(7751));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("8f19e546-a41d-488a-85df-558af0caf391"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 9, 16, 25, 54, 103, DateTimeKind.Local).AddTicks(7761));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("a838bccb-7786-462f-b4b0-018b9ce03560"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 9, 16, 25, 54, 103, DateTimeKind.Local).AddTicks(7758));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("c3266aac-f1b7-4d4a-afb1-8bb2dae6bc8f"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 9, 16, 25, 54, 103, DateTimeKind.Local).AddTicks(7753));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("c9ff969c-4f3a-4c6c-877f-dd36f07189ed"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 9, 16, 25, 54, 103, DateTimeKind.Local).AddTicks(7756));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("ccf59cf8-77d1-4f1e-82cc-42ee70dc0362"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 9, 16, 25, 54, 103, DateTimeKind.Local).AddTicks(7765));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("cd7bdc7f-6e90-46fc-a9a3-f5fab0169851"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 9, 16, 25, 54, 103, DateTimeKind.Local).AddTicks(7737));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("e21baed2-ac4d-4d91-af85-370f8ae5dd6c"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 9, 16, 25, 54, 103, DateTimeKind.Local).AddTicks(7772));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("f5c248ee-d9e6-44d3-9b16-117ceb616b9e"),
                column: "CreatedAt",
                value: new DateTime(2025, 1, 9, 16, 25, 54, 103, DateTimeKind.Local).AddTicks(7774));
        }
    }
}
