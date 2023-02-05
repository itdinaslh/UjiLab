using UjiLab.Data;
using UjiLab.Domain.Entities;
using UjiLab.Domain.Repositories;

namespace UjiLab.Domain.Services;

public class TipePengajuanService : ITipePengajuan
{
    private readonly AppDbContext context;

    public TipePengajuanService(AppDbContext context) { this.context = context; }

    public IQueryable<TipePengajuan> TipePengajuans => context.TipePengajuans;

    public async Task SaveDataAsync(TipePengajuan tipe)
    {
        if (tipe.TipePengajuanID == 0)
        {
            await context.TipePengajuans.AddAsync(tipe);
        } else
        {
            TipePengajuan? data = await context.TipePengajuans.FindAsync(tipe.TipePengajuanID);

            if (data != null)
            {
                data.NamaTipe = tipe.NamaTipe;
                data.JenisPengajuanID = tipe.JenisPengajuanID;
                data.UpdatedAt = DateTime.Now;
            }
        }

        await context.SaveChangesAsync();
    }
}
