using Microsoft.EntityFrameworkCore.Migrations;

namespace DingDongDelivey_Back.Migrations
{
    public partial class v20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 1,
                column: "password",
                value: "$2a$11$1XIsp3s1WkZ.vo1N.brTBurGfTYbdXGCL75zHeOUBvPl63deBEuDK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 2,
                column: "password",
                value: "$2a$11$PBvQJgbEi/CXfyQwP0Fk5uw3RTh2GFHSrlkSQPX0SYtzNmu2mLRzi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 3,
                column: "password",
                value: "$2a$11$gDfV6g.B1FuCXmYRIUXEMOMXcurMn9TnBztYuJnp6KG7vnLVj6fOS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 4,
                column: "password",
                value: "$2a$11$n1WIduSydY6J3frhcJWalugWpFvmyNh.IMijlxKJJ/uTNc7/ybpm6");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                column: "password",
                value: "$2a$11$MCMPz.Bhfs4SeDFUKesit.o8RXD8SRNzTqfV7/PMB5xfGpAteFqmq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 4,
                column: "password",
                value: "$2a$11$Kts6hyMzd8/CL46c50Eyz.vWSooX7j3H/2VRNoLrD/aM2eVqnbn0O");
        }
    }
}
