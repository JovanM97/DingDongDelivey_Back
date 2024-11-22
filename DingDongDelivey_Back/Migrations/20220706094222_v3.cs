using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DingDongDelivey_Back.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Product_orderItemid",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_userId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Order_orderId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_orderId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_orderItemid",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_userId",
                table: "Order");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "orderId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "orderItemid",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "orderQuantity",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.AddColumn<float>(
                name: "quantity",
                table: "Products",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "isAccepted",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "orderId");

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    orderItemsid = table.Column<int>(type: "int", nullable: false),
                    ordersorderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.orderItemsid, x.ordersorderId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Orders_ordersorderId",
                        column: x => x.ordersorderId,
                        principalTable: "Orders",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Products_orderItemsid",
                        column: x => x.orderItemsid,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_buyerId",
                table: "Orders",
                column: "buyerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ordersorderId",
                table: "OrderProduct",
                column: "ordersorderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_buyerId",
                table: "Orders",
                column: "buyerId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_buyerId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_buyerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "isAccepted",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.AddColumn<int>(
                name: "orderId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "orderItemid",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "orderQuantity",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "orderId");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "address", "dateOfBirth", "deliveryS", "email", "firstName", "hasOrder", "image", "isActive", "isDeleted", "lastName", "orderId", "password", "userT", "username" },
                values: new object[] { 1, "Novi Sad", new DateTime(1997, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "godlike.jovan@gmail.com", "Jovan", false, "", true, false, "Miljkovic", null, "jovan123", 0, "AdminJovan" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_orderId",
                table: "Users",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_orderItemid",
                table: "Order",
                column: "orderItemid");

            migrationBuilder.CreateIndex(
                name: "IX_Order_userId",
                table: "Order",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Product_orderItemid",
                table: "Order",
                column: "orderItemid",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_userId",
                table: "Order",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Order_orderId",
                table: "Users",
                column: "orderId",
                principalTable: "Order",
                principalColumn: "orderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
