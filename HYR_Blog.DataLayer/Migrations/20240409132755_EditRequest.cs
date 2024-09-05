using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HYR_Blog.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class EditRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 9, 16, 57, 53, 166, DateTimeKind.Local).AddTicks(7592),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 9, 15, 51, 56, 490, DateTimeKind.Local).AddTicks(7375));

            migrationBuilder.AlterColumn<long>(
                name: "RefId",
                table: "Pays",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Authority",
                table: "Pays",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 9, 15, 51, 56, 490, DateTimeKind.Local).AddTicks(7375),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 9, 16, 57, 53, 166, DateTimeKind.Local).AddTicks(7592));

            migrationBuilder.AlterColumn<long>(
                name: "RefId",
                table: "Pays",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Authority",
                table: "Pays",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
