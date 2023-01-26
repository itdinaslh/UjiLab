using UjiLab.Data;
using UjiLab.Domain.Entities;
using UjiLab.Domain.Repositories;

namespace UjiLab.Domain.Services;

public class TipeUsahaService : ITipeUsaha
{
    private readonly AppDbContext context;

    public TipeUsahaService(AppDbContext context) { this.context = context; }

    public IQueryable<TipeUsaha> TipeUsahas => context.TipeUsahas;
}
