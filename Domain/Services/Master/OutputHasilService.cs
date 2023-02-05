using UjiLab.Data;
using UjiLab.Domain.Entities;
using UjiLab.Domain.Repositories;

namespace UjiLab.Domain.Services;

public class OutputHasilService : IOutputHasil
{
    private readonly AppDbContext context;

    public OutputHasilService(AppDbContext context) { this.context = context; }

    public IQueryable<OutputHasil> OutputHasils => context.OutputHasils;

    public async Task SaveDataAsync(OutputHasil output)
    {
        if (output.OutputHasilID == 0)
        {
            await context.OutputHasils.AddAsync(output);
        } else
        {
            OutputHasil? data = await context.OutputHasils.FindAsync(output.OutputHasilID);

            if (data != null)
            {
                data.OutputName = output.OutputName;
                data.TipePengajuanID = output.TipePengajuanID;
                data.Kode = output.Kode;
                data.UpdatedAt = DateTime.Now;

                context.Update(data);
            }
        }

        await context.SaveChangesAsync();
    }
}
