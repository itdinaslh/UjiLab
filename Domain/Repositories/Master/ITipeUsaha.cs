using UjiLab.Domain.Entities;

namespace UjiLab.Domain.Repositories;

public interface ITipeUsaha
{
    IQueryable<TipeUsaha> TipeUsahas { get; }
}
