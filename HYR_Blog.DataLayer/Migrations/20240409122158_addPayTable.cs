using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HYR_Blog.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class addPayTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Users_UserId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Address_AddressId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "RequestPays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_Address_UserId",
                table: "Addresses",
                newName: "IX_Addresses_UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 9, 15, 51, 56, 490, DateTimeKind.Local).AddTicks(7375),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 9, 11, 41, 51, 727, DateTimeKind.Local).AddTicks(8895));

            migrationBuilder.AlterColumn<Guid>(
                name: "RequestPayId",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "AddressId");

            migrationBuilder.CreateTable(
                name: "Pays",
                columns: table => new
                {
                    RequestPayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsPay = table.Column<bool>(type: "bit", nullable: false),
                    RefId = table.Column<long>(type: "bigint", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TotalPrise = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Authority = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pays", x => x.RequestPayId);
                    table.ForeignKey(
                        name: "FK_Pays_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pays_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pays_CartId",
                table: "Pays",
                column: "CartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pays_UserId",
                table: "Pays",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users_UserId",
                table: "Addresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Addresses_AddressId",
                table: "Users",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_UserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Addresses_AddressId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Pays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_UserId",
                table: "Address",
                newName: "IX_Address_UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 9, 11, 41, 51, 727, DateTimeKind.Local).AddTicks(8895),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 9, 15, 51, 56, 490, DateTimeKind.Local).AddTicks(7375));

            migrationBuilder.AlterColumn<Guid>(
                name: "RequestPayId",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "AddressId");

            migrationBuilder.CreateTable(
                name: "RequestPays",
                columns: table => new
                {
                    RequestPayId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Authority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPay = table.Column<bool>(type: "bit", nullable: false),
                    RefId = table.Column<long>(type: "bigint", nullable: false),
                    TotalPrise = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestPays", x => x.RequestPayId);
                    table.ForeignKey(
                        name: "FK_RequestPays_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestPays_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestPays_CartId",
                table: "RequestPays",
                column: "CartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestPays_UserId",
                table: "RequestPays",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Users_UserId",
                table: "Address",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Address_AddressId",
                table: "Users",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "AddressId");
        }
    }
}
