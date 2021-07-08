using Microsoft.EntityFrameworkCore.Migrations;

namespace Hotstar_API.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_AspNetUsers_ApplicationUserId",
                table: "UserAccount");

            migrationBuilder.DropIndex(
                name: "IX_UserAccount_ApplicationUserId",
                table: "UserAccount");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "UserAccount",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserAccount",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAccount_AspNetUsers_ApplicationUserId",
                table: "UserAccount");

            migrationBuilder.DropIndex(
                name: "IX_UserAccount_ApplicationUserId",
                table: "UserAccount");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "UserAccount",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "UserAccount",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccount_ApplicationUserId",
                table: "UserAccount",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAccount_AspNetUsers_ApplicationUserId",
                table: "UserAccount",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
