using UjiLab.Domain.Entities;

namespace UjiLab.Domain.Repositories;

public interface ITipeLokasi
{
    IQueryable<TipeLokasi> TipeLokasis { get; }
}
