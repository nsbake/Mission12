using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission12.Migrations
{
    public partial class TimeChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "Id", "Date", "Email", "Name", "PhoneNumber", "Size", "Time" },
                values: new object[] { 1, "08/08/08", "floob@icon.com", "Barnabus", "615-616-6176", 6, "8:00AM - 9:00AM" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tours");
        }
    }
}
