using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimalWebApi.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PetName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "Breed", "Description", "PetName" },
                values: new object[] { "1", "10", "Abyssinian", "The Abyssinian /æbɪˈsɪniən/ is a breed of domestic short-haired cat with a distinctive \"ticked\" tabby coat, in which individual hairs are banded with different colors.[2] They are also known simply as Abys.", "Cat" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "Breed", "Description", "PetName" },
                values: new object[] { "2", "13", "Aegean", "Aegean cats (Greek: γάτα του Αιγαίου gáta tou Aigaíou) are a naturally occurring landrace of domestic cat originating from the Cycladic Islands of Greece and western Turkey. ", "Cat" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "Age", "Breed", "Description", "PetName" },
                values: new object[] { "3", "13", "Aegean", "Aegean cats (Greek: γάτα του Αιγαίου gáta tou Aigaíou) are a naturally occurring landrace of domestic cat originating from the Cycladic Islands of Greece and western Turkey.", "Cat" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");
        }
    }
}
