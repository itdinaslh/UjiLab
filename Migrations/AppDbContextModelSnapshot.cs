﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UjiLab.Data;

#nullable disable

namespace UjiLab.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UjiLab.Domain.Entities.BakuMutu", b =>
                {
                    b.Property<long>("BakuMutuID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("BakuMutuID"));

                    b.Property<double>("BiayaAlat")
                        .HasColumnType("double precision");

                    b.Property<double>("BiayaUji")
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(75)
                        .HasColumnType("character varying(75)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int?>("JenisBakuMutuID")
                        .HasColumnType("integer");

                    b.Property<int?>("MetodeParameterID")
                        .HasColumnType("integer");

                    b.Property<string>("NilaiBakuMutu")
                        .HasColumnType("text");

                    b.Property<int>("OutputHasilID")
                        .HasColumnType("integer");

                    b.Property<int>("ParameterID")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(75)
                        .HasColumnType("character varying(75)");

                    b.HasKey("BakuMutuID");

                    b.HasIndex("JenisBakuMutuID");

                    b.HasIndex("MetodeParameterID");

                    b.HasIndex("OutputHasilID");

                    b.HasIndex("ParameterID");

                    b.ToTable("BakuMutu");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.BidangUsaha", b =>
                {
                    b.Property<int>("BidangUsahaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BidangUsahaID"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NamaBidangUsaha")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("BidangUsahaID");

                    b.ToTable("BidangUsaha");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Alamat")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("BidangUsahaID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("EmailPIC")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("FileIzin")
                        .HasColumnType("text");

                    b.Property<string>("FileKTP")
                        .HasColumnType("text");

                    b.Property<string>("FileSuratKuasa")
                        .HasColumnType("text");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("boolean");

                    b.Property<string>("KelurahanID")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<string>("Keterangan")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("NIK")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.Property<string>("NamaClient")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("NamaPIC")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("PosisiPIC")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("character varying(75)");

                    b.Property<int>("StatusID")
                        .HasColumnType("integer");

                    b.Property<string>("TelpPIC")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<int>("TipeUsahaID")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uuid");

                    b.HasKey("ClientID");

                    b.HasIndex("BidangUsahaID");

                    b.HasIndex("KelurahanID");

                    b.HasIndex("StatusID");

                    b.HasIndex("TipeUsahaID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.JenisBakuMutu", b =>
                {
                    b.Property<int>("JenisBakuMutuID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("JenisBakuMutuID"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NamaJenis")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("JenisBakuMutuID");

                    b.ToTable("JenisBakuMutu");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.JenisParameter", b =>
                {
                    b.Property<int>("JenisParameterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("JenisParameterID"));

                    b.Property<string>("NamaJenis")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("JenisParameterID");

                    b.ToTable("JenisParameter");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.JenisPengajuan", b =>
                {
                    b.Property<int>("JenisPengajuanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("JenisPengajuanID"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NamaJenis")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("JenisPengajuanID");

                    b.ToTable("JenisPengajuan");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.Kabupaten", b =>
                {
                    b.Property<string>("KabupatenID")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<bool>("IsKota")
                        .HasColumnType("boolean");

                    b.Property<string>("Latitude")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Longitude")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("NamaKabupaten")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("ProvinsiID")
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)");

                    b.HasKey("KabupatenID");

                    b.HasIndex("ProvinsiID");

                    b.ToTable("Kabupaten");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.Kecamatan", b =>
                {
                    b.Property<string>("KecamatanID")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("KabupatenID")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Latitude")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Longitude")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("NamaKecamatan")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.HasKey("KecamatanID");

                    b.HasIndex("KabupatenID");

                    b.ToTable("Kecamatan");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.Kelurahan", b =>
                {
                    b.Property<string>("KelurahanID")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<string>("KecamatanID")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("Latitude")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Longitude")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("NamaKelurahan")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.HasKey("KelurahanID");

                    b.HasIndex("KecamatanID");

                    b.ToTable("Kelurahan");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.Kondisi", b =>
                {
                    b.Property<int>("KondisiID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("KondisiID"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NamaKondisi")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("KondisiID");

                    b.ToTable("Kondisi");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.Layanan", b =>
                {
                    b.Property<int>("LayananID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LayananID"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NamaLayanan")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("LayananID");

                    b.ToTable("Layanan");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.MetodeParameter", b =>
                {
                    b.Property<int>("MetodeParameterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MetodeParameterID"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NamaMetode")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("MetodeParameterID");

                    b.ToTable("MetodeParameter");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.MetodeSampling", b =>
                {
                    b.Property<int>("MetodeSamplingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MetodeSamplingID"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Deskripsi")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Kode")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("NamaMetode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("MetodeSamplingID");

                    b.ToTable("MetodeSampling");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.OutputHasil", b =>
                {
                    b.Property<int>("OutputHasilID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OutputHasilID"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Kode")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("OutputName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("TipePengajuanID")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("OutputHasilID");

                    b.HasIndex("TipePengajuanID");

                    b.ToTable("OutputHasil");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.Parameter", b =>
                {
                    b.Property<int>("ParameterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ParameterID"));

                    b.Property<double?>("BiayaAlat")
                        .HasColumnType("double precision");

                    b.Property<double?>("BiayaUji")
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("JenisParameterID")
                        .HasColumnType("integer");

                    b.Property<string>("NamaParameter")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Satuan")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ParameterID");

                    b.HasIndex("JenisParameterID");

                    b.ToTable("Parameter");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.Provinsi", b =>
                {
                    b.Property<string>("ProvinsiID")
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)");

                    b.Property<string>("HcKey")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("KodeNegara")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)");

                    b.Property<string>("Latitude")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Longitude")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("NamaProvinsi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("ProvinsiID");

                    b.ToTable("Provinsi");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.Status", b =>
                {
                    b.Property<int>("StatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StatusID"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("StatusID");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.TipeLokasi", b =>
                {
                    b.Property<int>("TipeLokasiID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TipeLokasiID"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NamaTipe")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("TipeLokasiID");

                    b.ToTable("TipeLokasi");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.TipePengajuan", b =>
                {
                    b.Property<int>("TipePengajuanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TipePengajuanID"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("JenisPengajuanID")
                        .HasColumnType("integer");

                    b.Property<string>("NamaTipe")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("TipePengajuanID");

                    b.HasIndex("JenisPengajuanID");

                    b.ToTable("TipePengajuan");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.TipeUsaha", b =>
                {
                    b.Property<int>("TipeUsahaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TipeUsahaID"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NamaTipe")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("TipeUsahaID");

                    b.ToTable("TipeUsaha");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.BakuMutu", b =>
                {
                    b.HasOne("UjiLab.Domain.Entities.JenisBakuMutu", "JenisBakuMutu")
                        .WithMany()
                        .HasForeignKey("JenisBakuMutuID");

                    b.HasOne("UjiLab.Domain.Entities.MetodeParameter", "MetodeParameter")
                        .WithMany()
                        .HasForeignKey("MetodeParameterID");

                    b.HasOne("UjiLab.Domain.Entities.OutputHasil", "OutputHasil")
                        .WithMany("BakuMutus")
                        .HasForeignKey("OutputHasilID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UjiLab.Domain.Entities.Parameter", "Parameter")
                        .WithMany()
                        .HasForeignKey("ParameterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JenisBakuMutu");

                    b.Navigation("MetodeParameter");

                    b.Navigation("OutputHasil");

                    b.Navigation("Parameter");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.Client", b =>
                {
                    b.HasOne("UjiLab.Domain.Entities.BidangUsaha", "BidangUsaha")
                        .WithMany("Clients")
                        .HasForeignKey("BidangUsahaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UjiLab.Domain.Entities.Kelurahan", "Kelurahan")
                        .WithMany("Clients")
                        .HasForeignKey("KelurahanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UjiLab.Domain.Entities.Status", "Status")
                        .WithMany("Clients")
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UjiLab.Domain.Entities.TipeUsaha", "TipeUsaha")
                        .WithMany("Clients")
                        .HasForeignKey("TipeUsahaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BidangUsaha");

                    b.Navigation("Kelurahan");

                    b.Navigation("Status");

                    b.Navigation("TipeUsaha");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.Kabupaten", b =>
                {
                    b.HasOne("UjiLab.Domain.Entities.Provinsi", "Provinsi")
                        .WithMany("Kabupatens")
                        .HasForeignKey("ProvinsiID");

                    b.Navigation("Provinsi");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.Kecamatan", b =>
                {
                    b.HasOne("UjiLab.Domain.Entities.Kabupaten", "Kabupaten")
                        .WithMany("Kecamatans")
                        .HasForeignKey("KabupatenID");

                    b.Navigation("Kabupaten");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.Kelurahan", b =>
                {
                    b.HasOne("UjiLab.Domain.Entities.Kecamatan", "Kecamatan")
                        .WithMany("Kelurahans")
                        .HasForeignKey("KecamatanID");

                    b.Navigation("Kecamatan");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.OutputHasil", b =>
                {
                    b.HasOne("UjiLab.Domain.Entities.TipePengajuan", "TipePengajuan")
                        .WithMany("OutputHasils")
                        .HasForeignKey("TipePengajuanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipePengajuan");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.Parameter", b =>
                {
                    b.HasOne("UjiLab.Domain.Entities.JenisParameter", "JenisParameter")
                        .WithMany("Parameters")
                        .HasForeignKey("JenisParameterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JenisParameter");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.TipePengajuan", b =>
                {
                    b.HasOne("UjiLab.Domain.Entities.JenisPengajuan", "JenisPengajuan")
                        .WithMany("TipePengajuans")
                        .HasForeignKey("JenisPengajuanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JenisPengajuan");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.BidangUsaha", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.JenisParameter", b =>
                {
                    b.Navigation("Parameters");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.JenisPengajuan", b =>
                {
                    b.Navigation("TipePengajuans");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.Kabupaten", b =>
                {
                    b.Navigation("Kecamatans");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.Kecamatan", b =>
                {
                    b.Navigation("Kelurahans");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.Kelurahan", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.OutputHasil", b =>
                {
                    b.Navigation("BakuMutus");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.Provinsi", b =>
                {
                    b.Navigation("Kabupatens");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.Status", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.TipePengajuan", b =>
                {
                    b.Navigation("OutputHasils");
                });

            modelBuilder.Entity("UjiLab.Domain.Entities.TipeUsaha", b =>
                {
                    b.Navigation("Clients");
                });
#pragma warning restore 612, 618
        }
    }
}
