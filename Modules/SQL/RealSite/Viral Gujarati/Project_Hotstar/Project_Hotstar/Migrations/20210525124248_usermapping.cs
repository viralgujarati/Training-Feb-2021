using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Hotstar.Migrations
{
    public partial class usermapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UserAccount",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_ApplicationUserId",
                table: "UserAccount",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccount_AspNetUsers_ApplicationUserId",
                table: "UserAccount",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_AspNetUsers_ApplicationUserId",
                table: "UserAccount");

            migrationBuilder.DropIndex(
                name: "IX_UserAccount_ApplicationUserId",
                table: "UserAccount");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserAccount");
        }
    }
}
