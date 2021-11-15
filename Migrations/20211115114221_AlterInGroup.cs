using Microsoft.EntityFrameworkCore.Migrations;

namespace Messenger.Migrations
{
    public partial class AlterInGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Group_Messages_PinMessageId",
                table: "Group");

            migrationBuilder.DropIndex(
                name: "IX_Group_PinMessageId",
                table: "Group");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Group_PinMessageId",
                table: "Group",
                column: "PinMessageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Group_Messages_PinMessageId",
                table: "Group",
                column: "PinMessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
