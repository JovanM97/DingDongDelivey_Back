using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DingDongDelivey_Back.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "id", "ingredients", "isDeleted", "name", "price", "quantity" },
                values: new object[,]
                {
                    { 1, "Chicken, beans, rice, tomatoes, corn, red salsa, nacho", false, "Chicken Burrito", 410f, -1f },
                    { 2, "100% beef burger, bacon, letuce, tomatoes, onions, secret sauce", false, "Beef Burger", 550f, -1f },
                    { 3, "Tomato sauce, mozzarella, basil", false, "Pizza Margharita 24cm", 320f, -1f },
                    { 4, "Tomato sauce, mozzarella, basil", false, "Pizza Margharita 32cm", 460f, -1f }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "address", "dateOfBirth", "deliveryS", "email", "firstName", "hasOrder", "image", "isActive", "isDeleted", "lastName", "password", "userT", "username" },
                values: new object[,]
                {
                    { 1, "Novi Sad", new DateTime(1997, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "godlike.jovan@gmail.com", "Jovan", false, "", true, false, "Miljkovic", "jovan123", 0, "AdminJovan" },
                    { 2, "Novi Sad", new DateTime(1997, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "godlike.jovan@gmail.com", "Jovan", false, "", true, false, "Miljkovic", "jovan123", 1, "DeliveryJovan" },
                    { 3, "Novi Sad", new DateTime(1997, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "godlike.jovan@gmail.com", "Jovan", false, "", true, false, "Miljkovic", "jovan123", 2, "BuyerJovan" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 3);
        }
    }
}
