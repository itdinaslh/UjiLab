using UjiLab.Data;
using UjiLab.Domain.Entities;
using UjiLab.Domain.Repositories;

namespace UjiLab.Domain.Services;

public class ParameterService : IParameter
{
    private readonly AppDbContext context;

    public ParameterService(AppDbContext context) => this.context = context;

    public IQueryable<Parameter> Parameters => context.Parameters;

    public IQueryable<JenisParameter> JenisParameters => context.JenisParameters;

    public IQueryable<MetodeParameter> MetodeParameters => context.MetodeParameters;

    public async Task SaveDataAsync(Parameter param)
    {
        if (param.ParameterID == 0)
        {
            await context.Parameters.AddAsync(param);
        } else
        {
            Parameter? data = await context.Parameters.FindAsync(param.ParameterID);

            if (data is not null)
            {
                data.NamaParameter = param.NamaParameter;
                data.Satuan = param.Satuan;
                data.BiayaUji = param.BiayaUji;
                data.BiayaAlat = param.BiayaAlat is not null ? param.BiayaAlat : 0;
                data.JenisParameterID = param.JenisParameterID;
                data.UpdatedAt = DateTime.Now;

                context.Update(data);
            }
        }

        await context.SaveChangesAsync();
    }

    public async Task SaveMetodeAsync(MetodeParameter metode)
    {
        if (metode.MetodeParameterID == 0)
        {
            await context.MetodeParameters.AddAsync(metode);
        } else
        {
            MetodeParameter? data = await context.MetodeParameters.FindAsync(metode.MetodeParameterID);

            if (data is not null)
            {
                data.NamaMetode = metode.NamaMetode;

                context.MetodeParameters.Update(data);
            }
        }

        await context.SaveChangesAsync();
    }
}
