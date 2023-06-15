using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppData.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_sanPhams",
                table: "sanPhams");

            migrationBuilder.RenameTable(
                name: "sanPhams",
                newName: "SanPham");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SanPham",
                table: "SanPham",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SanPham",
                table: "SanPham");

            migrationBuilder.RenameTable(
                name: "SanPham",
                newName: "sanPhams");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sanPhams",
                table: "sanPhams",
                column: "Id");
        }
    }
}
