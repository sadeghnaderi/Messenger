using Microsoft.EntityFrameworkCore.Migrations;

namespace Messenger.Migrations
{
    public partial class ReceiverTypeToConversation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceiverTypeId",
                table: "Conversation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Conversation_ReceiverTypeId",
                table: "Conversation",
                column: "ReceiverTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Conversation_ReceiverType_ReceiverTypeId",
                table: "Conversation",
                column: "ReceiverTypeId",
                principalTable: "ReceiverType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Conversation_ReceiverType_ReceiverTypeId",
                table: "Conversation");

            migrationBuilder.DropIndex(
                name: "IX_Conversation_ReceiverTypeId",
                table: "Conversation");

            migrationBuilder.DropColumn(
                name: "ReceiverTypeId",
                table: "Conversation");
        }
    }
}
