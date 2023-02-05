using Microsoft.EntityFrameworkCore;
using UjiLab.Domain.Entities;

namespace UjiLab.Data;

public class AppDbContext : DbContext
{
#nullable disable

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Wilayah
    public DbSet<Provinsi> Provinsis { get; set; }
    public DbSet<Kabupaten> Kabupatens { get; set; }
    public DbSet<Kecamatan> Kecamatans { get; set; }
    public DbSet<Kelurahan> Kelurahans { get; set; }

    // Master
    public DbSet<BidangUsaha> BidangUsahas { get; set; }
    public DbSet<Layanan> Layanans { get; set; }
    public DbSet<Kondisi> Kondisis { get; set; }
    public DbSet<MetodeSampling> MetodeSamplings { get; set; }
    public DbSet<TipeUsaha> TipeUsahas { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<TipeLokasi> TipeLokasis { get; set; }
    public DbSet<JenisPengajuan> JenisPengajuans { get; set; }
    public DbSet<TipePengajuan> TipePengajuans { get; set; }
    public DbSet<OutputHasil> OutputHasils { get; set; }
    public DbSet<BakuMutu> BakuMutus { get; set; }

    // Main
    public DbSet<Client> Clients { get; set; }
}
