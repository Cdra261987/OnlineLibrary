using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLibrary.Data.Migrations
{
    public partial class CreateForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CustomerBooks_BookId",
                table: "CustomerBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBooks_CustomerId",
                table: "CustomerBooks",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBooks_Books_BookId",
                table: "CustomerBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerBooks_Costumers_CustomerId",
                table: "CustomerBooks",
                column: "CustomerId",
                principalTable: "Costumers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBooks_Books_BookId",
                table: "CustomerBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerBooks_Costumers_CustomerId",
                table: "CustomerBooks");

            migrationBuilder.DropIndex(
                name: "IX_CustomerBooks_BookId",
                table: "CustomerBooks");

            migrationBuilder.DropIndex(
                name: "IX_CustomerBooks_CustomerId",
                table: "CustomerBooks");
        }
    }
}
