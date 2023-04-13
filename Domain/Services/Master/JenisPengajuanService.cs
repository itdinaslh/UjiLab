using UjiLab.Data;
using UjiLab.Domain.Entities;
using UjiLab.Domain.Repositories;

namespace UjiLab.Domain.Services;

public class JenisPengajuanService : IJenisPengajuan
{
    private readonly AppDbContext context;

    public JenisPengajuanService(AppDbContext context) => this.context = context;

    public IQueryable<JenisPengajuan> JenisPengajuans => context.JenisPengajuans;
}
