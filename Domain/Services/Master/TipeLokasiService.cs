using UjiLab.Data;
using UjiLab.Domain.Entities;
using UjiLab.Domain.Repositories;

namespace UjiLab.Domain.Services;

public class TipeLokasiService : ITipeLokasi
{
    private readonly AppDbContext context;

    public TipeLokasiService(AppDbContext context) => this.context = context;

    public IQueryable<TipeLokasi> TipeLokasis => context.TipeLokasis;
}
