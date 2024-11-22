using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DingDongDelivey_Back.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userId", "address", "dateOfBirth", "deliveryS", "email", "firstName", "hasOrder", "image", "isActive", "isDeleted", "lastName", "orderId", "password", "userT", "username" },
                values: new object[] { 1, "Novi Sad", new DateTime(1997, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "godlike.jovan@gmail.com", "Jovan", false, "", true, false, "Miljkovic", null, "jovan123", 0, "AdminJovan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 1);
        }
    }
}
