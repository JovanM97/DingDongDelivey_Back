using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DingDongDelivey_Back.Migrations
{
    public partial class v16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "orderId", "buyerId", "deliverymanId", "isAccepted", "isDelivered", "orderAddress", "orderComment", "orderPrice", "timeTillDelivery" },
                values: new object[] { 3, 3, 2, false, false, "Bulevar Oslobodjenja 220", "", 930f, new DateTime(2022, 7, 13, 23, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 1,
                column: "password",
                value: "$2a$11$2znggNtogS85PuFSG0xMTuK0ENcoGrHiRGgLyLg9gFXp7R2npYLQO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 2,
                column: "password",
                value: "$2a$11$tKc8W92xeSiZi7bL6jK37.D/sSZEYEgP1Kd8ljU04BLM33QcCzleO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 3,
                columns: new[] { "hasOrder", "password" },
                values: new object[] { true, "$2a$11$MCMPz.Bhfs4SeDFUKesit.o8RXD8SRNzTqfV7/PMB5xfGpAteFqmq" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "address", "dateOfBirth", "deliveryS", "email", "firstName", "hasOrder", "image", "isActive", "isDeleted", "lastName", "password", "userT", "username" },
                values: new object[] { 4, "Novi Sad", new DateTime(1997, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "deliveryjovan2@gmail.com", "Jovan", false, "", false, false, "Miljkovic", "$2a$11$Kts6hyMzd8/CL46c50Eyz.vWSooX7j3H/2VRNoLrD/aM2eVqnbn0O", 1, "DeliveryJovan" });

            migrationBuilder.InsertData(
                table: "ProductOrders",
                columns: new[] { "OrderId", "ProductId", "ProductQuantity" },
                values: new object[] { 3, 3, 3 });

            migrationBuilder.InsertData(
                table: "ProductOrders",
                columns: new[] { "OrderId", "ProductId", "ProductQuantity" },
                values: new object[] { 3, 4, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ProductOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "orderId",
                keyValue: 3);

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
                columns: new[] { "hasOrder", "password" },
                values: new object[] { false, "$2a$11$.oiXBzE1RK1plaTTwj1VnOyYSaXFPK.ospDGP8dNN5jGcNiPYLvdC" });
        }
    }
}
