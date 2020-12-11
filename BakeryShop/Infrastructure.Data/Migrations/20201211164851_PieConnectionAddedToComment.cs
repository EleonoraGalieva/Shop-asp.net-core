using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class PieConnectionAddedToComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PieId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PieId",
                table: "Comments",
                column: "PieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Pies_PieId",
                table: "Comments",
                column: "PieId",
                principalTable: "Pies",
                principalColumn: "PieId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Pies_PieId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PieId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PieId",
                table: "Comments");
        }
    }
}
