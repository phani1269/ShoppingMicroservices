using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCart.API.Migrations
{
    public partial class updated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderedOn",
                table: "cartLists",
                newName: "CreatedOn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "cartLists",
                newName: "OrderedOn");
        }
    }
}
