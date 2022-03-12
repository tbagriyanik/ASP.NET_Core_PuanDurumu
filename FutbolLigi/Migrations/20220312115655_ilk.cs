using Microsoft.EntityFrameworkCore.Migrations;

namespace FutbolLigi.Migrations
{
    public partial class ilk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PuanTablosu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TakimAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Galibiyet = table.Column<int>(type: "int", nullable: true),
                    Beraberlik = table.Column<int>(type: "int", nullable: true),
                    Maglubiyet = table.Column<int>(type: "int", nullable: true),
                    AtilanGol = table.Column<int>(type: "int", nullable: true),
                    YenilenGol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuanTablosu", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PuanTablosu");
        }
    }
}
