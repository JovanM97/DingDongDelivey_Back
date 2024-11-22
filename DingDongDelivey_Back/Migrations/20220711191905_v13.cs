using Microsoft.EntityFrameworkCore.Migrations;

namespace DingDongDelivey_Back.Migrations
{
    public partial class v13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 1,
                column: "password",
                value: "$2a$11$axSSAR.7XYnocKEZlzBHsuggaH/hQLWBXEkihla/wMbG0HuPWfVnW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 2,
                column: "password",
                value: "$2a$11$Ag5EU9rC3CKbmDijHDlLeey7h2FyWEtEFTXB44lDTEuDl/yVoHmOq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "userId",
                keyValue: 3,
                column: "password",
                value: "$2a$11$a7utoii2u50dtd6BCCgJTODsZK0/frI7Fi4SVc4rb0auBJB8LjO3K");
        }
    }
}
