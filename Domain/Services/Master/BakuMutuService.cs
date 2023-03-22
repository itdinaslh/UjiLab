using UjiLab.Data;
using UjiLab.Domain.Entities;
using UjiLab.Domain.Repositories;

namespace UjiLab.Domain.Services;

public class BakuMutuService : IBakuMutu
{
    private AppDbContext context;

    public BakuMutuService(AppDbContext context) => this.context = context;

    public IQueryable<BakuMutu> BakuMutus => context.BakuMutus;

    public async Task SaveDataAsync(BakuMutu mutu)
    {
        if (mutu.BakuMutuID == 0)
        {
            await context.BakuMutus.AddAsync(mutu);
        } else
        {
            BakuMutu? data = await context.BakuMutus.FindAsync(mutu.BakuMutuID);

            if (data is not null)
            {
                data.NamaBakuMutu = mutu.NamaBakuMutu;
                data.OutputHasilID = mutu.OutputHasilID;

                context.BakuMutus.Update(mutu);
            }
        }

        await context.SaveChangesAsync();
    }
}
