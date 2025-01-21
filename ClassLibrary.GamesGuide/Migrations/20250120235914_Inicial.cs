using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibrary.GamesGuide.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GG_Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    ImgUrl = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GG_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GG_Backgrounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgUrl = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    Id_Game = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GG_Backgrounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GG_Backgrounds_GG_Games_Id_Game",
                        column: x => x.Id_Game,
                        principalTable: "GG_Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GG_Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    ImgUrl = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    Id_Game = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GG_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GG_Characters_GG_Games_Id_Game",
                        column: x => x.Id_Game,
                        principalTable: "GG_Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GG_Guides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Id_Game = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GG_Guides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GG_Guides_GG_Games_Id_Game",
                        column: x => x.Id_Game,
                        principalTable: "GG_Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GG_Sources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    ImgUrl = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    Id_Game = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GG_Sources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GG_Sources_GG_Games_Id_Game",
                        column: x => x.Id_Game,
                        principalTable: "GG_Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GG_Backgrounds_Id_Game",
                table: "GG_Backgrounds",
                column: "Id_Game");

            migrationBuilder.CreateIndex(
                name: "IX_GG_Characters_Id_Game",
                table: "GG_Characters",
                column: "Id_Game");

            migrationBuilder.CreateIndex(
                name: "IX_GG_Guides_Id_Game",
                table: "GG_Guides",
                column: "Id_Game");

            migrationBuilder.CreateIndex(
                name: "IX_GG_Sources_Id_Game",
                table: "GG_Sources",
                column: "Id_Game");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GG_Backgrounds");

            migrationBuilder.DropTable(
                name: "GG_Characters");

            migrationBuilder.DropTable(
                name: "GG_Guides");

            migrationBuilder.DropTable(
                name: "GG_Sources");

            migrationBuilder.DropTable(
                name: "GG_Games");
        }
    }
}
