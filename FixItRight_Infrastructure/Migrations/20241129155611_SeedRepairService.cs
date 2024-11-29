using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FixItRight_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedRepairService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Active", "CreatedAt", "Description", "Image", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("85aa164a-a52c-4af3-95fd-29890f8df531"), true, new DateTime(2024, 11, 29, 22, 56, 10, 801, DateTimeKind.Local).AddTicks(9204), "Air Condition Repair", "https://fixitright.blob.core.windows.net/fixitright/aircondition.jpg", "Air Condition Repair", 200000.0, null },
                    { new Guid("8f19e546-a41d-488a-85df-558af0caf391"), true, new DateTime(2024, 11, 29, 22, 56, 10, 801, DateTimeKind.Local).AddTicks(9211), "Oven Repair", "https://fixitright.blob.core.windows.net/fixitright/oven.jpg", "Oven Repair", 200000.0, null },
                    { new Guid("a838bccb-7786-462f-b4b0-018b9ce03560"), true, new DateTime(2024, 11, 29, 22, 56, 10, 801, DateTimeKind.Local).AddTicks(9209), "Microwave Repair", "https://fixitright.blob.core.windows.net/fixitright/microwave.jpg", "Microwave Repair", 200000.0, null },
                    { new Guid("c3266aac-f1b7-4d4a-afb1-8bb2dae6bc8f"), true, new DateTime(2024, 11, 29, 22, 56, 10, 801, DateTimeKind.Local).AddTicks(9206), "Washing Machine Repair", "https://fixitright.blob.core.windows.net/fixitright/washing.jpg", "Washing Machine Repair", 200000.0, null },
                    { new Guid("c9ff969c-4f3a-4c6c-877f-dd36f07189ed"), true, new DateTime(2024, 11, 29, 22, 56, 10, 801, DateTimeKind.Local).AddTicks(9208), "TV Repair", "https://fixitright.blob.core.windows.net/fixitright/tv.jpg", "TV Repair", 200000.0, null },
                    { new Guid("ccf59cf8-77d1-4f1e-82cc-42ee70dc0362"), true, new DateTime(2024, 11, 29, 22, 56, 10, 801, DateTimeKind.Local).AddTicks(9214), "Dishwasher Repair", "https://fixitright.blob.core.windows.net/fixitright/dishwasher.jpg", "Dishwasher Repair", 200000.0, null },
                    { new Guid("cd7bdc7f-6e90-46fc-a9a3-f5fab0169851"), true, new DateTime(2024, 11, 29, 22, 56, 10, 801, DateTimeKind.Local).AddTicks(9188), "Fridge Repair", "https://fixitright.blob.core.windows.net/fixitright/fridge.jpg", "Fridge Repair", 200000.0, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("85aa164a-a52c-4af3-95fd-29890f8df531"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("8f19e546-a41d-488a-85df-558af0caf391"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("a838bccb-7786-462f-b4b0-018b9ce03560"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("c3266aac-f1b7-4d4a-afb1-8bb2dae6bc8f"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("c9ff969c-4f3a-4c6c-877f-dd36f07189ed"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("ccf59cf8-77d1-4f1e-82cc-42ee70dc0362"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("cd7bdc7f-6e90-46fc-a9a3-f5fab0169851"));
        }
    }
}
