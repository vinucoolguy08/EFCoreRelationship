using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreRelationship.Migrations
{
    public partial class AddUserCharacterNewRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_users_userId",
                table: "Characters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Characters",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Characters_userId",
                table: "Characters",
                newName: "IX_Characters_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Users_UserId",
                table: "Characters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Users_UserId",
                table: "Characters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Characters",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Characters_UserId",
                table: "Characters",
                newName: "IX_Characters_userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_users_userId",
                table: "Characters",
                column: "userId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
