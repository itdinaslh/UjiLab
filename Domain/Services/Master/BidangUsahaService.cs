using UjiLab.Data;
using UjiLab.Domain.Entities;
using UjiLab.Domain.Repositories;

namespace UjiLab.Domain.Services;

public class BidangUsahaService : IBidangUsaha
{
    private readonly AppDbContext context;

    public BidangUsahaService(AppDbContext context) { this.context = context; }

    public IQueryable<BidangUsaha> BidangUsahas => context.BidangUsahas;

    public async Task SaveDataAsync(BidangUsaha usaha)
    {
        if (usaha.BidangUsahaID == 0)
        {
            await context.AddAsync(usaha);
        } else
        {
            BidangUsaha? data = await context.BidangUsahas.FindAsync(usaha.BidangUsahaID);

            if (data is not null)
            {
                data.NamaBidangUsaha = usaha.NamaBidangUsaha;
                data.UpdatedAt = DateTime.Now;
            }
        }

        await context.SaveChangesAsync();
    }
}
