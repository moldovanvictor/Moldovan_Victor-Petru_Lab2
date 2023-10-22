using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moldovan_Victor_Petru_Lab2.Migrations
{
    public partial class AuthorKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "AuthorFK",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.ID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorFK",
                table: "Book");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropIndex(
                name: "IX_Book_AuthorFK",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "AuthorFK",
                table: "Book");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
