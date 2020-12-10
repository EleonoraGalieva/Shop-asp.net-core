using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class PieImageFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PieImage",
                table: "Pies");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Pies",
                newName: "ImageThumbnail");

            migrationBuilder.RenameColumn(
                name: "ImageThumbnailUrl",
                table: "Pies",
                newName: "Image");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageThumbnail",
                table: "Pies",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Pies",
                newName: "ImageThumbnailUrl");

            migrationBuilder.AddColumn<byte[]>(
                name: "PieImage",
                table: "Pies",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
