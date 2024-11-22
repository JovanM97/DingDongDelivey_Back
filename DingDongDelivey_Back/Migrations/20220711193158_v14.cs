using Microsoft.EntityFrameworkCore.Migrations;

namespace DingDongDelivey_Back.Migrations
{
    public partial class v14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 1,
                column: "password",
                value: "$2a$11$0pXJx62AWPzqnSVvHLeOQeWwCBOGlbDry0Zk.50zChBvguGKqs0Uy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 2,
                column: "password",
                value: "$2a$11$g/ge1Ytb6z18w2fMMx6k9OUT9rQ8hvBcxNTSahoV9Ow5ARQAxHLjm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 3,
                column: "password",
                value: "$2a$11$fqZyr7zV3vvKrmn5DdxihOvC2ZTqWWnqAEOyhEpN8fCS5R04fWGmm");
        }
    }
}
