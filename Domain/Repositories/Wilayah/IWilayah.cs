using UjiLab.Domain.Entities;

namespace UjiLab.Domain.Repositories
{
    public interface IWilayah
    {
        IQueryable<Provinsi> Provinsis { get; }

        IQueryable<Kabupaten> Kabupatens { get; }

        IQueryable<Kecamatan> Kecamatans { get; }

        IQueryable<Kelurahan> Kelurahans { get; }
    }
}
