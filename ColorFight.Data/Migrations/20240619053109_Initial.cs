using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ColorFight.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColorStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorStats", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ColorStats",
                columns: new[] { "Id", "Count", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Primary" },
                    { 2, 1, "Secondary" },
                    { 3, 1, "Success" },
                    { 4, 1, "Danger" },
                    { 5, 1, "Warning" },
                    { 6, 1, "Info" },
                    { 7, 1, "Light" },
                    { 8, 1, "Dark" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColorStats");
        }
    }
}
