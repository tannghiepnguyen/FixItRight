using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixItRight_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdjustEntityInService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("85aa164a-a52c-4af3-95fd-29890f8df531"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 13, 32, 52, 831, DateTimeKind.Local).AddTicks(1986));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("8f19e546-a41d-488a-85df-558af0caf391"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 13, 32, 52, 831, DateTimeKind.Local).AddTicks(1998));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("a838bccb-7786-462f-b4b0-018b9ce03560"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 13, 32, 52, 831, DateTimeKind.Local).AddTicks(1996));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("c3266aac-f1b7-4d4a-afb1-8bb2dae6bc8f"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 13, 32, 52, 831, DateTimeKind.Local).AddTicks(1991));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("c9ff969c-4f3a-4c6c-877f-dd36f07189ed"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 13, 32, 52, 831, DateTimeKind.Local).AddTicks(1993));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("ccf59cf8-77d1-4f1e-82cc-42ee70dc0362"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 13, 32, 52, 831, DateTimeKind.Local).AddTicks(1999));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("cd7bdc7f-6e90-46fc-a9a3-f5fab0169851"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 21, 13, 32, 52, 831, DateTimeKind.Local).AddTicks(1970));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("85aa164a-a52c-4af3-95fd-29890f8df531"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 3, 22, 59, 5, 268, DateTimeKind.Local).AddTicks(3362));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("8f19e546-a41d-488a-85df-558af0caf391"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 3, 22, 59, 5, 268, DateTimeKind.Local).AddTicks(3370));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("a838bccb-7786-462f-b4b0-018b9ce03560"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 3, 22, 59, 5, 268, DateTimeKind.Local).AddTicks(3368));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("c3266aac-f1b7-4d4a-afb1-8bb2dae6bc8f"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 3, 22, 59, 5, 268, DateTimeKind.Local).AddTicks(3364));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("c9ff969c-4f3a-4c6c-877f-dd36f07189ed"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 3, 22, 59, 5, 268, DateTimeKind.Local).AddTicks(3366));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("ccf59cf8-77d1-4f1e-82cc-42ee70dc0362"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 3, 22, 59, 5, 268, DateTimeKind.Local).AddTicks(3371));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("cd7bdc7f-6e90-46fc-a9a3-f5fab0169851"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 3, 22, 59, 5, 268, DateTimeKind.Local).AddTicks(3351));
        }
    }
}
