using UjiLab.Data;
using UjiLab.Domain.Entities;
using UjiLab.Domain.Repositories;

namespace UjiLab.Domain.Services;

public class KondisiService : IKondisi
{
    private readonly AppDbContext context;

    public KondisiService(AppDbContext context)
    {
        this.context = context;
    }

    public IQueryable<Kondisi> Kondisis => context.Kondisis;

    public async Task SaveDataAsync(Kondisi kondisi)
    {
        if (kondisi.KondisiID == 0)
        {
            await context.AddAsync(kondisi);
        } else
        {
            Kondisi? data = await context.Kondisis.FindAsync(kondisi.KondisiID);

            if (data != null)
            {
                data.NamaKondisi = kondisi.NamaKondisi;
                data.UpdatedAt = DateTime.Now;
            }
        }

        await context.SaveChangesAsync();
    }
}
