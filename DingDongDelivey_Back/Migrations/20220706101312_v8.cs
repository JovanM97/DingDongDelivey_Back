using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DingDongDelivey_Back.Migrations
{
    public partial class v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 6);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "address", "dateOfBirth", "deliveryS", "email", "firstName", "hasOrder", "image", "isActive", "isDeleted", "lastName", "password", "userT", "username" },
                values: new object[] { 5, "Novi Sad", new DateTime(1997, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "godlike.jovan@gmail.com", "Jovan", false, "", true, false, "Miljkovic", "jovan123", 1, "DeliveryJovan" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "address", "dateOfBirth", "deliveryS", "email", "firstName", "hasOrder", "image", "isActive", "isDeleted", "lastName", "password", "userT", "username" },
                values: new object[] { 6, "Novi Sad", new DateTime(1997, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "godlike.jovan@gmail.com", "Jovan", false, "", true, false, "Miljkovic", "jovan123", 2, "BuyerJovan" });
        }
    }
}
