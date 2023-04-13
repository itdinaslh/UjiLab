using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UjiLab.Migrations
{
    public partial class AlterMyBakuMutu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "BakuMutu",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "BakuMutu");
        }
    }
}
