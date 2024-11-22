using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DingDongDelivey_Back.Migrations
{
    public partial class v10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.AddColumn<int>(
                name: "deliverymanId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductOrders",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrders", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_ProductOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "orderId", "buyerId", "deliverymanId", "isAccepted", "isDelivered", "orderAddress", "orderComment", "orderPrice", "timeTillDelivery" },
                values: new object[,]
                {
                    { 1, 3, 2, true, false, "Futoska 120", "", 1110f, new DateTime(2022, 6, 8, 16, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 3, 2, true, true, "Bulevar Oslobodjenja 220", "", 930f, new DateTime(2022, 6, 1, 16, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 2,
                column: "email",
                value: "deliveryjovan@gmail.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 3,
                column: "email",
                value: "buyerjovan@gmail.com");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_OrderId",
                table: "ProductOrders",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductOrders");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "orderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "orderId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "deliverymanId",
                table: "Orders");

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 2,
                column: "email",
                value: "godlike.jovan@gmail.com");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 3,
                column: "email",
                value: "godlike.jovan@gmail.com");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ordersorderId",
                table: "OrderProduct",
                column: "ordersorderId");
        }
    }
}
