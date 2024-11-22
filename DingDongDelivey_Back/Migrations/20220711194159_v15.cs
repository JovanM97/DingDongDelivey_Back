using Microsoft.EntityFrameworkCore.Migrations;

namespace DingDongDelivey_Back.Migrations
{
    public partial class v15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductQuantity",
                table: "ProductOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ProductOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1 },
                column: "ProductQuantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 2 },
                column: "ProductQuantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ProductOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 3 },
                column: "ProductQuantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ProductOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 4 },
                column: "ProductQuantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 1,
                column: "password",
                value: "$2a$11$0rKPvScznWa5tg97EdlbhudfQXUyVUGg3FEczy2Dd.RhuaFuQcCQu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 2,
                column: "password",
                value: "$2a$11$mEGkhAe11MqgQlk/vtdMB.7VzDgNtF.J1XZI5KYXNBcOSQTcLBI/e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 3,
                column: "password",
                value: "$2a$11$.oiXBzE1RK1plaTTwj1VnOyYSaXFPK.ospDGP8dNN5jGcNiPYLvdC");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductQuantity",
                table: "ProductOrders");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 1,
                column: "password",
                value: "$2a$11$xeEmRVgB2OvVGRSylHoHp.NbKFYUI2KIvtG1GPhTPH71dAhJ7WkPm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 2,
                column: "password",
                value: "$2a$11$VhYm8oNL/90gsA008oCiKeM85ojfsrvTd2Jq3e60SGnfsL1g6KN2a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 3,
                column: "password",
                value: "$2a$11$xtKdjYhdq3B3YWCODb3YUelrLAcsquBUsIVD46Ai1uBOSYpeQbHqa");
        }
    }
}
