using UjiLab.Data;
using UjiLab.Domain.Entities;
using UjiLab.Domain.Repositories;

namespace UjiLab.Domain.Services;

public class LayananService : ILayanan
{
    private readonly AppDbContext context;

    public LayananService(AppDbContext context) { this.context = context; }

    public IQueryable<Layanan> Layanans => context.Layanans;

    public async Task SaveDataAsync(Layanan layanan)
    {
        if (layanan.LayananID == 0)
        {
            await context.AddAsync(layanan);
        } else
        {
            Layanan? data = await context.Layanans.FindAsync(layanan.LayananID);

            if (data is not null)
            {
                data.NamaLayanan = layanan.NamaLayanan;
                data.UpdatedAt = DateTime.Now;
            }
        }

        await context.SaveChangesAsync();
    }
}
