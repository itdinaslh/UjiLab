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
}
