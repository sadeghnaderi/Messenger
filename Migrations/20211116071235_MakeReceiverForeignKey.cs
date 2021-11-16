using Microsoft.EntityFrameworkCore.Migrations;

namespace Messenger.Migrations
{
    public partial class MakeReceiverForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReceiverId",
                table: "Conversation",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conversation_ReceiverId",
                table: "Conversation",
                column: "ReceiverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conversation_User_ReceiverId",
                table: "Conversation",
                column: "ReceiverId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conversation_User_ReceiverId",
                table: "Conversation");

            migrationBuilder.DropIndex(
                name: "IX_Conversation_ReceiverId",
                table: "Conversation");

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverId",
                table: "Conversation",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
