using UjiLab.Data;
using UjiLab.Domain.Entities;
using UjiLab.Domain.Repositories;

namespace UjiLab.Domain.Services;

public class MetodeSamplingService : IMetodeSampling
{
    private readonly AppDbContext context;

    public MetodeSamplingService(AppDbContext context) { this.context = context; }

    public IQueryable<MetodeSampling> MetodeSamplings => context.MetodeSamplings;

    public async Task SaveDataAsync(MetodeSampling metode)
    {
        if (metode.MetodeSamplingID == 0)
        {
            await context.AddAsync(metode);
        } else
        {
            MetodeSampling? data = await context.MetodeSamplings.FindAsync(metode.MetodeSamplingID);

            if (data is not null)
            {
                data.NamaMetode = metode.NamaMetode;
                data.Kode = metode.Kode;
                data.Deskripsi = metode.Deskripsi;
                data.UpdatedAt = DateTime.Now;
            }
        }

        await context.SaveChangesAsync();
    }
}
