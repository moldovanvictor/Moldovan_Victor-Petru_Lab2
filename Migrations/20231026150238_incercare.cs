using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moldovan_Victor_Petru_Lab2.Migrations
{
    public partial class incercare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorFK",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_AuthorFK",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "AuthorFK",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorID",
                table: "Book",
                column: "AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorID",
                table: "Book",
                column: "AuthorID",
                principalTable: "Author",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorID",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_AuthorID",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "AuthorFK",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorFK",
                table: "Book",
                column: "AuthorFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorFK",
                table: "Book",
                column: "AuthorFK",
                principalTable: "Author",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
