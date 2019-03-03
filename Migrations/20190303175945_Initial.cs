using System;

using Microsoft.EntityFrameworkCore.Migrations;

namespace wg_backend.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:cat_color", "black,white,black & white,red,red & white,red & black & white");

            migrationBuilder.CreateTable(
                name: "cat_colors_info",
                columns: table => new
                {
                    color = table.Column<cat_color>(nullable: false),
                    count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cat_colors_info", x => x.color);
                });

            migrationBuilder.CreateTable(
                name: "cats",
                columns: table => new
                {
                    name = table.Column<string>(nullable: false),
                    color = table.Column<cat_color>(nullable: false),
                    tail_length = table.Column<int>(nullable: false),
                    whiskers_length = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cats", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "cats_stat",
                columns: table => new
                {
                    tail_length_mean = table.Column<double>(nullable: false),
                    tail_length_median = table.Column<double>(nullable: false),
                    tail_length_mode = table.Column<int[]>(nullable: true),
                    whiskers_length_mean = table.Column<double>(nullable: false),
                    whiskers_length_median = table.Column<double>(nullable: false),
                    whiskers_length_mode = table.Column<int[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cats_stat", x => x.tail_length_mean);
                });

            migrationBuilder.CreateTable(
                name: "dogs",
                columns: table => new
                {
                    name = table.Column<string>(nullable: false),
                    color = table.Column<cat_color>(nullable: false),
                    tail_length = table.Column<int>(nullable: false),
                    whiskers_length = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dogs", x => x.name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cat_colors_info");

            migrationBuilder.DropTable(
                name: "cats");

            migrationBuilder.DropTable(
                name: "cats_stat");

            migrationBuilder.DropTable(
                name: "dogs");
        }
    }
}
