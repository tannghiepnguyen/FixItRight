using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixItRight_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdjustEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_AspNetUsers_CustomerId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_AspNetUsers_MechanistId",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_CustomerId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Chats");

            migrationBuilder.RenameColumn(
                name: "MechanistId",
                table: "Chats",
                newName: "SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_MechanistId",
                table: "Chats",
                newName: "IX_Chats_SenderId");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_AspNetUsers_SenderId",
                table: "Chats",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_AspNetUsers_SenderId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Chats",
                newName: "MechanistId");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_SenderId",
                table: "Chats",
                newName: "IX_Chats_MechanistId");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Chats",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("85aa164a-a52c-4af3-95fd-29890f8df531"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 1, 22, 28, 27, 26, DateTimeKind.Local).AddTicks(6345));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("8f19e546-a41d-488a-85df-558af0caf391"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 1, 22, 28, 27, 26, DateTimeKind.Local).AddTicks(6352));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("a838bccb-7786-462f-b4b0-018b9ce03560"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 1, 22, 28, 27, 26, DateTimeKind.Local).AddTicks(6351));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("c3266aac-f1b7-4d4a-afb1-8bb2dae6bc8f"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 1, 22, 28, 27, 26, DateTimeKind.Local).AddTicks(6347));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("c9ff969c-4f3a-4c6c-877f-dd36f07189ed"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 1, 22, 28, 27, 26, DateTimeKind.Local).AddTicks(6349));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("ccf59cf8-77d1-4f1e-82cc-42ee70dc0362"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 1, 22, 28, 27, 26, DateTimeKind.Local).AddTicks(6354));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("cd7bdc7f-6e90-46fc-a9a3-f5fab0169851"),
                column: "CreatedAt",
                value: new DateTime(2024, 12, 1, 22, 28, 27, 26, DateTimeKind.Local).AddTicks(6332));

            migrationBuilder.CreateIndex(
                name: "IX_Chats_CustomerId",
                table: "Chats",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_AspNetUsers_CustomerId",
                table: "Chats",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_AspNetUsers_MechanistId",
                table: "Chats",
                column: "MechanistId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
