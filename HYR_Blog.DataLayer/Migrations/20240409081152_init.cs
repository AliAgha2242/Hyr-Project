using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HYR_Blog.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    MetaTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyWorld = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsSpecial = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "DiscountCodes",
                columns: table => new
                {
                    DiscountCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisCountCodeText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LifeTimeDay = table.Column<byte>(type: "tinyint", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UseCountAllowed = table.Column<byte>(type: "tinyint", nullable: false),
                    UseCount = table.Column<byte>(type: "tinyint", nullable: false),
                    DisCountAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCodes", x => x.DiscountCodeId);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "Transportation",
                columns: table => new
                {
                    TransportationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportationCompany = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PrisePerKg = table.Column<int>(type: "int", nullable: false),
                    InitialPrise = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportation", x => x.TransportationId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRoleTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Prise = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: true, defaultValue: 500),
                    Visit = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 4, 9, 11, 41, 51, 727, DateTimeKind.Local).AddTicks(8895)),
                    Score = table.Column<float>(type: "real", nullable: false, defaultValue: 5f),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsSpecial = table.Column<bool>(type: "bit", nullable: false),
                    MetaTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyWorld = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelationKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inventory = table.Column<int>(type: "int", nullable: true, defaultValue: 10),
                    PriseByDiscount = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SellCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageDirectory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProperties",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProperties", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_ProductProperties_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    City = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ContinueAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ByFromUsCount = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    UserRoleId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId");
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "UserRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsFinish = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CartCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportationId = table.Column<int>(type: "int", nullable: false),
                    TotalPrise = table.Column<int>(type: "int", nullable: false),
                    RequestPayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Carts_Transportation_TransportationId",
                        column: x => x.TransportationId,
                        principalTable: "Transportation",
                        principalColumn: "TransportationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Score = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SendCode = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SumPrise = table.Column<int>(type: "int", nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DiscountCodeId = table.Column<int>(type: "int", nullable: true),
                    TransportationId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_DiscountCodes_DiscountCodeId",
                        column: x => x.DiscountCodeId,
                        principalTable: "DiscountCodes",
                        principalColumn: "DiscountCodeId");
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatus_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Transportation_TransportationId",
                        column: x => x.TransportationId,
                        principalTable: "Transportation",
                        principalColumn: "TransportationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prise = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestPays",
                columns: table => new
                {
                    RequestPayId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "StatusId", "Priority", "StatusTitle" },
                values: new object[,]
                {
                    { 1, 3, "پذیرفته شده" },
                    { 2, 2, "لغو شده" },
                    { 3, 5, "نهایی" },
                    { 4, 4, "ارسال شده" },
                    { 5, 1, "سفارش جدید" }
                });

            migrationBuilder.InsertData(
                table: "Transportation",
                columns: new[] { "TransportationId", "InitialPrise", "PrisePerKg", "TransportationCompany" },
                values: new object[,]
                {
                    { 1, 40000, 10000, "تیپاکس" },
                    { 2, 35000, 10000, "پست ویژه" },
                    { 3, 50000, 12000, "پست ویژه" },
                    { 4, 30000, 9000, "پست سفارشی" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleId", "UserRoleTitle" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Person" },
                    { 3, "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                table: "Address",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_TransportationId",
                table: "Carts",
                column: "TransportationId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressId",
                table: "Orders",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DiscountCodeId",
                table: "Orders",
                column: "DiscountCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SendCode",
                table: "Orders",
                column: "SendCode",
                unique: true,
                filter: "[SendCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TransportationId",
                table: "Orders",
                column: "TransportationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperties_ProductId",
                table: "ProductProperties",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductName",
                table: "Products",
                column: "ProductName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestPays_CartId",
                table: "RequestPays",
                column: "CartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestPays_UserId",
                table: "RequestPays",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Users_UserId",
                table: "Address",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Users_UserId",
                table: "Address");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProductProperties");

            migrationBuilder.DropTable(
                name: "RequestPays");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "DiscountCodes");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Transportation");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "UserRoles");
        }
    }
}
