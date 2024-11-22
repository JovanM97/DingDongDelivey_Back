using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DingDongDelivey_Back.Migrations
{
    public partial class v21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 1,
                columns: new[] { "dateOfBirth", "email", "firstName", "lastName", "password", "username" },
                values: new object[] { new DateTime(1997, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "srdjandzinovic97@gmail.com", "Srdjan", "Dzinovic", "$2a$11$Q9sZ9INBMTL1exGa8e6qheWptYNBkSI2Ve0uU0tNEICQdZ/sJ5tMe", "AdminDzin" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 2,
                columns: new[] { "dateOfBirth", "email", "firstName", "lastName", "password", "username" },
                values: new object[] { new DateTime(1997, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "deliverydzin@gmail.com", "Srdjan", "Dzinovic", "$2a$11$jylEeH11gwmRvkTCzvhey.KU3EIdG03o.2Y/./g8RGTds3Jq8UfXK", "DeliveryDzin" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 3,
                columns: new[] { "dateOfBirth", "email", "firstName", "lastName", "password", "username" },
                values: new object[] { new DateTime(1997, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "buyerdzin@gmail.com", "Srdjan", "Dzinovic", "$2a$11$bT4B9qiZkVJUJUhOZOgjH.SCeothtsKEgL32GuuUu3D1aeZby0gDm", "BuyerDzin" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 4,
                columns: new[] { "dateOfBirth", "email", "firstName", "lastName", "password", "username" },
                values: new object[] { new DateTime(1997, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "deliverydzin2@gmail.com", "Srdjan", "Dzinovic", "$2a$11$nC/GEQVHCflwjhAzM60p5u2Ss/uxD4a8aHGxQHsuMPjlgzpsSJPrW", "DeliveryDzin2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 1,
                columns: new[] { "dateOfBirth", "email", "firstName", "lastName", "password", "username" },
                values: new object[] { new DateTime(1997, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "godlike.jovan@gmail.com", "Jovan", "Miljkovic", "$2a$11$1XIsp3s1WkZ.vo1N.brTBurGfTYbdXGCL75zHeOUBvPl63deBEuDK", "AdminJovan" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 2,
                columns: new[] { "dateOfBirth", "email", "firstName", "lastName", "password", "username" },
                values: new object[] { new DateTime(1997, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "deliveryjovan@gmail.com", "Jovan", "Miljkovic", "$2a$11$PBvQJgbEi/CXfyQwP0Fk5uw3RTh2GFHSrlkSQPX0SYtzNmu2mLRzi", "DeliveryJovan" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 3,
                columns: new[] { "dateOfBirth", "email", "firstName", "lastName", "password", "username" },
                values: new object[] { new DateTime(1997, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "buyerjovan@gmail.com", "Jovan", "Miljkovic", "$2a$11$gDfV6g.B1FuCXmYRIUXEMOMXcurMn9TnBztYuJnp6KG7vnLVj6fOS", "BuyerJovan" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 4,
                columns: new[] { "dateOfBirth", "email", "firstName", "lastName", "password", "username" },
                values: new object[] { new DateTime(1997, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "deliveryjovan2@gmail.com", "Jovan", "Miljkovic", "$2a$11$n1WIduSydY6J3frhcJWalugWpFvmyNh.IMijlxKJJ/uTNc7/ybpm6", "DeliveryJovan" });
        }
    }
}
