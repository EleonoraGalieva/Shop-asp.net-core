using Microsoft.EntityFrameworkCore.Migrations;

namespace BakeryShop.Migrations
{
    public partial class PiesAddedAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pies",
                columns: new[] { "PieId", "AllergyInfo", "CategoryId", "ImageThumbnailUrl", "ImageUrl", "InStock", "IsPieOfTheWeek", "LongDescription", "Name", "Price", "ShortDescription" },
                values: new object[] { 2, "Contains sugar, milk, gluten", 2, "https://images.ctfassets.net/3s5io6mnxfqz/3RG0DDIeU6oW5XG04n2JSN/6f55a3abe26a310adf6ac1eeccbd811e/AdobeStock_177050939.jpeg?w=800&fm=jpg&fl=progressive", "https://images.ctfassets.net/3s5io6mnxfqz/3RG0DDIeU6oW5XG04n2JSN/6f55a3abe26a310adf6ac1eeccbd811e/AdobeStock_177050939.jpeg?w=800&fm=jpg&fl=progressive", true, true, "This is absolutely the BEST homemade pumpkin pie recipe! Make it with canned or fresh pumpkin puree and up to several days ahead. Also freezes well! Thanksgiving pie never looked so good or so easy.", "Autumn Wonders", 16.45m, "Yummy pie for autmn." });

            migrationBuilder.InsertData(
                table: "Pies",
                columns: new[] { "PieId", "AllergyInfo", "CategoryId", "ImageThumbnailUrl", "ImageUrl", "InStock", "IsPieOfTheWeek", "LongDescription", "Name", "Price", "ShortDescription" },
                values: new object[] { 3, "Contains sugar, milk, gluten", 3, "https://i2.wp.com/www.sugarspunrun.com/wp-content/uploads/2019/01/Best-Cheesecake-Recipe-2-1-of-1-4.jpg", "https://i2.wp.com/www.sugarspunrun.com/wp-content/uploads/2019/01/Best-Cheesecake-Recipe-2-1-of-1-4.jpg", true, false, "Simple and classic! The texture is smooth, rich, and creamy, served over a crisp homemade graham cracker crust.", "Soft cheesecake", 10.20m, "THE BEST cheesecake of your life!" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pies",
                keyColumn: "PieId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pies",
                keyColumn: "PieId",
                keyValue: 3);
        }
    }
}
