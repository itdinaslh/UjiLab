using UjiLab.Domain.Entities;

namespace UjiLab.Domain.Repositories;

public interface IBidangUsaha
{
    IQueryable<BidangUsaha> BidangUsahas { get; }

    Task SaveDataAsync(BidangUsaha usaha);
}
