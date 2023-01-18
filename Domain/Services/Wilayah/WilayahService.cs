using UjiLab.Data;
using UjiLab.Domain.Entities;
using UjiLab.Domain.Repositories;

namespace UjiLab.Domain.Services;

public class WilayahService : IWilayah
{
    private readonly AppDbContext context;

    public WilayahService(AppDbContext context) { this.context = context; }

    public IQueryable<Provinsi> Provinsis => context.Provinsis;

    public IQueryable<Kabupaten> Kabupatens => context.Kabupatens;

    public IQueryable<Kecamatan> Kecamatans => context.Kecamatans;

    public IQueryable<Kelurahan> Kelurahans => context.Kelurahans;
}
