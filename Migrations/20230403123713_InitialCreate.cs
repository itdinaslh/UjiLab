using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UjiLab.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BidangUsaha",
                columns: table => new
                {
                    BidangUsahaID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaBidangUsaha = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidangUsaha", x => x.BidangUsahaID);
                });

            migrationBuilder.CreateTable(
                name: "JenisParameter",
                columns: table => new
                {
                    JenisParameterID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaJenis = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JenisParameter", x => x.JenisParameterID);
                });

            migrationBuilder.CreateTable(
                name: "JenisPengajuan",
                columns: table => new
                {
                    JenisPengajuanID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaJenis = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JenisPengajuan", x => x.JenisPengajuanID);
                });

            migrationBuilder.CreateTable(
                name: "Kondisi",
                columns: table => new
                {
                    KondisiID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaKondisi = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kondisi", x => x.KondisiID);
                });

            migrationBuilder.CreateTable(
                name: "Layanan",
                columns: table => new
                {
                    LayananID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaLayanan = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Layanan", x => x.LayananID);
                });

            migrationBuilder.CreateTable(
                name: "MetodeSampling",
                columns: table => new
                {
                    MetodeSamplingID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaMetode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Kode = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Deskripsi = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodeSampling", x => x.MetodeSamplingID);
                });

            migrationBuilder.CreateTable(
                name: "Provinsi",
                columns: table => new
                {
                    ProvinsiID = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    NamaProvinsi = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    HcKey = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Latitude = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Longitude = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    KodeNegara = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinsi", x => x.ProvinsiID);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "TipeLokasi",
                columns: table => new
                {
                    TipeLokasiID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaTipe = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipeLokasi", x => x.TipeLokasiID);
                });

            migrationBuilder.CreateTable(
                name: "TipeUsaha",
                columns: table => new
                {
                    TipeUsahaID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaTipe = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipeUsaha", x => x.TipeUsahaID);
                });

            migrationBuilder.CreateTable(
                name: "Parameter",
                columns: table => new
                {
                    ParameterID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaParameter = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    JenisParameterID = table.Column<int>(type: "integer", nullable: false),
                    Satuan = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameter", x => x.ParameterID);
                    table.ForeignKey(
                        name: "FK_Parameter_JenisParameter_JenisParameterID",
                        column: x => x.JenisParameterID,
                        principalTable: "JenisParameter",
                        principalColumn: "JenisParameterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipePengajuan",
                columns: table => new
                {
                    TipePengajuanID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaTipe = table.Column<string>(type: "text", nullable: true),
                    JenisPengajuanID = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipePengajuan", x => x.TipePengajuanID);
                    table.ForeignKey(
                        name: "FK_TipePengajuan_JenisPengajuan_JenisPengajuanID",
                        column: x => x.JenisPengajuanID,
                        principalTable: "JenisPengajuan",
                        principalColumn: "JenisPengajuanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kabupaten",
                columns: table => new
                {
                    KabupatenID = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    NamaKabupaten = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    IsKota = table.Column<bool>(type: "boolean", nullable: false),
                    Latitude = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Longitude = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    ProvinsiID = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kabupaten", x => x.KabupatenID);
                    table.ForeignKey(
                        name: "FK_Kabupaten_Provinsi_ProvinsiID",
                        column: x => x.ProvinsiID,
                        principalTable: "Provinsi",
                        principalColumn: "ProvinsiID");
                });

            migrationBuilder.CreateTable(
                name: "OutputHasil",
                columns: table => new
                {
                    OutputHasilID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OutputName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TipePengajuanID = table.Column<int>(type: "integer", nullable: false),
                    Kode = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputHasil", x => x.OutputHasilID);
                    table.ForeignKey(
                        name: "FK_OutputHasil_TipePengajuan_TipePengajuanID",
                        column: x => x.TipePengajuanID,
                        principalTable: "TipePengajuan",
                        principalColumn: "TipePengajuanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kecamatan",
                columns: table => new
                {
                    KecamatanID = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    NamaKecamatan = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Latitude = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Longitude = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    KabupatenID = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kecamatan", x => x.KecamatanID);
                    table.ForeignKey(
                        name: "FK_Kecamatan_Kabupaten_KabupatenID",
                        column: x => x.KabupatenID,
                        principalTable: "Kabupaten",
                        principalColumn: "KabupatenID");
                });

            migrationBuilder.CreateTable(
                name: "BakuMutu",
                columns: table => new
                {
                    BakuMutuID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NamaBakuMutu = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    OutputHasilID = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakuMutu", x => x.BakuMutuID);
                    table.ForeignKey(
                        name: "FK_BakuMutu_OutputHasil_OutputHasilID",
                        column: x => x.OutputHasilID,
                        principalTable: "OutputHasil",
                        principalColumn: "OutputHasilID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kelurahan",
                columns: table => new
                {
                    KelurahanID = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    NamaKelurahan = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Latitude = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Longitude = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    KecamatanID = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kelurahan", x => x.KelurahanID);
                    table.ForeignKey(
                        name: "FK_Kelurahan_Kecamatan_KecamatanID",
                        column: x => x.KecamatanID,
                        principalTable: "Kecamatan",
                        principalColumn: "KecamatanID");
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    NamaClient = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    TipeUsahaID = table.Column<int>(type: "integer", nullable: false),
                    BidangUsahaID = table.Column<int>(type: "integer", nullable: false),
                    Phone = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    KelurahanID = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Alamat = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    NamaPIC = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    NIK = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    PosisiPIC = table.Column<string>(type: "character varying(75)", maxLength: 75, nullable: false),
                    EmailPIC = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    TelpPIC = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    FileKTP = table.Column<string>(type: "text", nullable: true),
                    FileSuratKuasa = table.Column<string>(type: "text", nullable: true),
                    FileIzin = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StatusID = table.Column<int>(type: "integer", nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    Keterangan = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                    table.ForeignKey(
                        name: "FK_Clients_BidangUsaha_BidangUsahaID",
                        column: x => x.BidangUsahaID,
                        principalTable: "BidangUsaha",
                        principalColumn: "BidangUsahaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_Kelurahan_KelurahanID",
                        column: x => x.KelurahanID,
                        principalTable: "Kelurahan",
                        principalColumn: "KelurahanID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_Status_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Status",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_TipeUsaha_TipeUsahaID",
                        column: x => x.TipeUsahaID,
                        principalTable: "TipeUsaha",
                        principalColumn: "TipeUsahaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BakuMutu_OutputHasilID",
                table: "BakuMutu",
                column: "OutputHasilID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_BidangUsahaID",
                table: "Clients",
                column: "BidangUsahaID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_KelurahanID",
                table: "Clients",
                column: "KelurahanID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_StatusID",
                table: "Clients",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_TipeUsahaID",
                table: "Clients",
                column: "TipeUsahaID");

            migrationBuilder.CreateIndex(
                name: "IX_Kabupaten_ProvinsiID",
                table: "Kabupaten",
                column: "ProvinsiID");

            migrationBuilder.CreateIndex(
                name: "IX_Kecamatan_KabupatenID",
                table: "Kecamatan",
                column: "KabupatenID");

            migrationBuilder.CreateIndex(
                name: "IX_Kelurahan_KecamatanID",
                table: "Kelurahan",
                column: "KecamatanID");

            migrationBuilder.CreateIndex(
                name: "IX_OutputHasil_TipePengajuanID",
                table: "OutputHasil",
                column: "TipePengajuanID");

            migrationBuilder.CreateIndex(
                name: "IX_Parameter_JenisParameterID",
                table: "Parameter",
                column: "JenisParameterID");

            migrationBuilder.CreateIndex(
                name: "IX_TipePengajuan_JenisPengajuanID",
                table: "TipePengajuan",
                column: "JenisPengajuanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BakuMutu");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Kondisi");

            migrationBuilder.DropTable(
                name: "Layanan");

            migrationBuilder.DropTable(
                name: "MetodeSampling");

            migrationBuilder.DropTable(
                name: "Parameter");

            migrationBuilder.DropTable(
                name: "TipeLokasi");

            migrationBuilder.DropTable(
                name: "OutputHasil");

            migrationBuilder.DropTable(
                name: "BidangUsaha");

            migrationBuilder.DropTable(
                name: "Kelurahan");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "TipeUsaha");

            migrationBuilder.DropTable(
                name: "JenisParameter");

            migrationBuilder.DropTable(
                name: "TipePengajuan");

            migrationBuilder.DropTable(
                name: "Kecamatan");

            migrationBuilder.DropTable(
                name: "JenisPengajuan");

            migrationBuilder.DropTable(
                name: "Kabupaten");

            migrationBuilder.DropTable(
                name: "Provinsi");
        }
    }
}
