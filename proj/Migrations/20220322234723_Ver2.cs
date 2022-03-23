using Microsoft.EntityFrameworkCore.Migrations;

namespace proj.Migrations
{
    public partial class Ver2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MernoMesto",
                table: "weatherdatas");

            migrationBuilder.AddColumn<string>(
                name: "Ukratko",
                table: "weatherdatas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ukratko",
                table: "weatherdatas");

            migrationBuilder.AddColumn<string>(
                name: "MernoMesto",
                table: "weatherdatas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
