using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HYR_Blog.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class FixOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_AddressId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 15, 11, 31, 59, 209, DateTimeKind.Local).AddTicks(9149),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 9, 16, 57, 53, 166, DateTimeKind.Local).AddTicks(7592));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 9, 16, 57, 53, 166, DateTimeKind.Local).AddTicks(7592),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 15, 11, 31, 59, 209, DateTimeKind.Local).AddTicks(9149));

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressId",
                table: "Orders",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_AddressId",
                table: "Orders",
                column: "AddressId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
