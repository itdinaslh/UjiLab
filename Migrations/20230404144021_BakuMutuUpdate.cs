using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UjiLab.Migrations
{
    public partial class BakuMutuUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NamaBakuMutu",
                table: "BakuMutu");

            migrationBuilder.AddColumn<double>(
                name: "Harga",
                table: "Parameter",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BiayaAlat",
                table: "BakuMutu",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BiayaUji",
                table: "BakuMutu",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BakuMutu",
                type: "character varying(75)",
                maxLength: 75,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JenisBakuMutuID",
                table: "BakuMutu",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MetodeParameterID",
                table: "BakuMutu",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NilaiBakuMutu",
                table: "BakuMutu",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParameterID",
                table: "BakuMutu",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "BakuMutu",
                type: "character varying(75)",
                maxLength: 75,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JenisBakuMutu",
                columns: table => new
                {
                    JenisBakuMutuID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaJenis = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JenisBakuMutu", x => x.JenisBakuMutuID);
                });

            migrationBuilder.CreateTable(
                name: "MetodeParameter",
                columns: table => new
                {
                    MetodeParameterID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaMetode = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodeParameter", x => x.MetodeParameterID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BakuMutu_JenisBakuMutuID",
                table: "BakuMutu",
                column: "JenisBakuMutuID");

            migrationBuilder.CreateIndex(
                name: "IX_BakuMutu_MetodeParameterID",
                table: "BakuMutu",
                column: "MetodeParameterID");

            migrationBuilder.CreateIndex(
                name: "IX_BakuMutu_ParameterID",
                table: "BakuMutu",
                column: "ParameterID");

            migrationBuilder.AddForeignKey(
                name: "FK_BakuMutu_JenisBakuMutu_JenisBakuMutuID",
                table: "BakuMutu",
                column: "JenisBakuMutuID",
                principalTable: "JenisBakuMutu",
                principalColumn: "JenisBakuMutuID");

            migrationBuilder.AddForeignKey(
                name: "FK_BakuMutu_MetodeParameter_MetodeParameterID",
                table: "BakuMutu",
                column: "MetodeParameterID",
                principalTable: "MetodeParameter",
                principalColumn: "MetodeParameterID");

            migrationBuilder.AddForeignKey(
                name: "FK_BakuMutu_Parameter_ParameterID",
                table: "BakuMutu",
                column: "ParameterID",
                principalTable: "Parameter",
                principalColumn: "ParameterID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BakuMutu_JenisBakuMutu_JenisBakuMutuID",
                table: "BakuMutu");

            migrationBuilder.DropForeignKey(
                name: "FK_BakuMutu_MetodeParameter_MetodeParameterID",
                table: "BakuMutu");

            migrationBuilder.DropForeignKey(
                name: "FK_BakuMutu_Parameter_ParameterID",
                table: "BakuMutu");

            migrationBuilder.DropTable(
                name: "JenisBakuMutu");

            migrationBuilder.DropTable(
                name: "MetodeParameter");

            migrationBuilder.DropIndex(
                name: "IX_BakuMutu_JenisBakuMutuID",
                table: "BakuMutu");

            migrationBuilder.DropIndex(
                name: "IX_BakuMutu_MetodeParameterID",
                table: "BakuMutu");

            migrationBuilder.DropIndex(
                name: "IX_BakuMutu_ParameterID",
                table: "BakuMutu");

            migrationBuilder.DropColumn(
                name: "Harga",
                table: "Parameter");

            migrationBuilder.DropColumn(
                name: "BiayaAlat",
                table: "BakuMutu");

            migrationBuilder.DropColumn(
                name: "BiayaUji",
                table: "BakuMutu");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BakuMutu");

            migrationBuilder.DropColumn(
                name: "JenisBakuMutuID",
                table: "BakuMutu");

            migrationBuilder.DropColumn(
                name: "MetodeParameterID",
                table: "BakuMutu");

            migrationBuilder.DropColumn(
                name: "NilaiBakuMutu",
                table: "BakuMutu");

            migrationBuilder.DropColumn(
                name: "ParameterID",
                table: "BakuMutu");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BakuMutu");

            migrationBuilder.AddColumn<string>(
                name: "NamaBakuMutu",
                table: "BakuMutu",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
