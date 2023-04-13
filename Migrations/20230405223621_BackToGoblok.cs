using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UjiLab.Migrations
{
    public partial class BackToGoblok : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JenisBakuMutu_OutputHasil_OutputHasilID",
                table: "JenisBakuMutu");

            migrationBuilder.DropIndex(
                name: "IX_JenisBakuMutu_OutputHasilID",
                table: "JenisBakuMutu");

            migrationBuilder.DropColumn(
                name: "OutputHasilID",
                table: "JenisBakuMutu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OutputHasilID",
                table: "JenisBakuMutu",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JenisBakuMutu_OutputHasilID",
                table: "JenisBakuMutu",
                column: "OutputHasilID");

            migrationBuilder.AddForeignKey(
                name: "FK_JenisBakuMutu_OutputHasil_OutputHasilID",
                table: "JenisBakuMutu",
                column: "OutputHasilID",
                principalTable: "OutputHasil",
                principalColumn: "OutputHasilID");
        }
    }
}
