using UjiLab.Data;
using UjiLab.Domain.Entities;
using UjiLab.Domain.Repositories;

namespace UjiLab.Domain.Services;

public class BakuMutuService : IBakuMutu
{
    private AppDbContext context;

    public BakuMutuService(AppDbContext context) => this.context = context;

    public IQueryable<BakuMutu> BakuMutus => context.BakuMutus;

    public IQueryable<JenisBakuMutu> JenisBakuMutus => context.JenisBakuMutus;

    public async Task SaveBakuMutuAsync(BakuMutu mutu)
    {
        if (mutu.BakuMutuID == 0)
        {
            await context.BakuMutus.AddAsync(mutu);
        } else
        {
            BakuMutu? data = await context.BakuMutus.FindAsync(mutu.BakuMutuID);

            if (data is not null)
            {
                data.OutputHasilID = mutu.OutputHasilID;
                data.ParameterID = mutu.ParameterID;
                data.MetodeParameterID = mutu.MetodeParameterID;
                data.JenisBakuMutuID = mutu.JenisBakuMutuID;
                data.BiayaUji = mutu.BiayaUji;
                data.BiayaAlat = mutu.BiayaAlat;
                data.IsActive = mutu.IsActive;
                data.UpdatedBy = mutu.UpdatedBy;
                data.UpdatedAt = DateTime.Now;

                context.BakuMutus.Update(data);
            }
        }

        await context.SaveChangesAsync();
    }

    public async Task SaveJenisAsync(JenisBakuMutu jenis)
    {
        if (jenis.JenisBakuMutuID == 0) 
        {
            await context.JenisBakuMutus.AddAsync(jenis);
        } else
        {
            JenisBakuMutu? data = await context.JenisBakuMutus.FindAsync(jenis.JenisBakuMutuID);

            if (data is not null)
            {
                data.NamaJenis = jenis.NamaJenis;

                context.JenisBakuMutus.Update(data);
            }
        }

        await context.SaveChangesAsync();
    }
}
