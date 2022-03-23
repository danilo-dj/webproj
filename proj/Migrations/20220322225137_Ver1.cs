using Microsoft.EntityFrameworkCore.Migrations;

namespace proj.Migrations
{
    public partial class Ver1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "airqdatas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qindex = table.Column<int>(type: "int", nullable: false),
                    PMtwo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_airqdatas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "citymuns",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZIPcode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_citymuns", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "weatherdatas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MernoMesto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    Humidity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weatherdatas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "mernamesta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    weatherdataID = table.Column<int>(type: "int", nullable: true),
                    airqdataID = table.Column<int>(type: "int", nullable: true),
                    citymunID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mernamesta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_mernamesta_airqdatas_airqdataID",
                        column: x => x.airqdataID,
                        principalTable: "airqdatas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mernamesta_citymuns_citymunID",
                        column: x => x.citymunID,
                        principalTable: "citymuns",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_mernamesta_weatherdatas_weatherdataID",
                        column: x => x.weatherdataID,
                        principalTable: "weatherdatas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mernamesta_airqdataID",
                table: "mernamesta",
                column: "airqdataID");

            migrationBuilder.CreateIndex(
                name: "IX_mernamesta_citymunID",
                table: "mernamesta",
                column: "citymunID");

            migrationBuilder.CreateIndex(
                name: "IX_mernamesta_weatherdataID",
                table: "mernamesta",
                column: "weatherdataID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mernamesta");

            migrationBuilder.DropTable(
                name: "airqdatas");

            migrationBuilder.DropTable(
                name: "citymuns");

            migrationBuilder.DropTable(
                name: "weatherdatas");
        }
    }
}
