using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UjiLab.Migrations
{
    public partial class CreateMasterPengujian : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clients_Statuses_StatusID",
                table: "clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses");

            migrationBuilder.RenameTable(
                name: "Statuses",
                newName: "statuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_statuses",
                table: "statuses",
                column: "StatusID");

            migrationBuilder.CreateTable(
                name: "jenis_pengajuan",
                columns: table => new
                {
                    JenisPengajuanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NamaJenis = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jenis_pengajuan", x => x.JenisPengajuanID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipe_lokasi",
                columns: table => new
                {
                    TipeLokasiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NamaTipe = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipe_lokasi", x => x.TipeLokasiID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipe_pengajuan",
                columns: table => new
                {
                    TipePengajuanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NamaTipe = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    JenisPengajuanID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipe_pengajuan", x => x.TipePengajuanID);
                    table.ForeignKey(
                        name: "FK_tipe_pengajuan_jenis_pengajuan_JenisPengajuanID",
                        column: x => x.JenisPengajuanID,
                        principalTable: "jenis_pengajuan",
                        principalColumn: "JenisPengajuanID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "output_hasil",
                columns: table => new
                {
                    OutputHasilID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OutputName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipePengajuanID = table.Column<int>(type: "int", nullable: false),
                    Kode = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_output_hasil", x => x.OutputHasilID);
                    table.ForeignKey(
                        name: "FK_output_hasil_tipe_pengajuan_TipePengajuanID",
                        column: x => x.TipePengajuanID,
                        principalTable: "tipe_pengajuan",
                        principalColumn: "TipePengajuanID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "baku_mutu",
                columns: table => new
                {
                    BakuMutuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NamaBakuMutu = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OutputHasilID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_baku_mutu", x => x.BakuMutuID);
                    table.ForeignKey(
                        name: "FK_baku_mutu_output_hasil_OutputHasilID",
                        column: x => x.OutputHasilID,
                        principalTable: "output_hasil",
                        principalColumn: "OutputHasilID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_baku_mutu_OutputHasilID",
                table: "baku_mutu",
                column: "OutputHasilID");

            migrationBuilder.CreateIndex(
                name: "IX_output_hasil_TipePengajuanID",
                table: "output_hasil",
                column: "TipePengajuanID");

            migrationBuilder.CreateIndex(
                name: "IX_tipe_pengajuan_JenisPengajuanID",
                table: "tipe_pengajuan",
                column: "JenisPengajuanID");

            migrationBuilder.AddForeignKey(
                name: "FK_clients_statuses_StatusID",
                table: "clients",
                column: "StatusID",
                principalTable: "statuses",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clients_statuses_StatusID",
                table: "clients");

            migrationBuilder.DropTable(
                name: "baku_mutu");

            migrationBuilder.DropTable(
                name: "tipe_lokasi");

            migrationBuilder.DropTable(
                name: "output_hasil");

            migrationBuilder.DropTable(
                name: "tipe_pengajuan");

            migrationBuilder.DropTable(
                name: "jenis_pengajuan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_statuses",
                table: "statuses");

            migrationBuilder.RenameTable(
                name: "statuses",
                newName: "Statuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses",
                column: "StatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_clients_Statuses_StatusID",
                table: "clients",
                column: "StatusID",
                principalTable: "Statuses",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
