using Microsoft.EntityFrameworkCore.Migrations;

namespace Messenger.Migrations
{
    public partial class EditMessageReaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Reaction_ReactionId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ReactionId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ReactionId",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "Reaction",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reaction",
                table: "Messages");

            migrationBuilder.AddColumn<int>(
                name: "ReactionId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReactionId",
                table: "Messages",
                column: "ReactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Reaction_ReactionId",
                table: "Messages",
                column: "ReactionId",
                principalTable: "Reaction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
