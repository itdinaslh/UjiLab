using UjiLab.Domain.Entities;

namespace UjiLab.Domain.Repositories;

public interface IBakuMutu
{
    IQueryable<BakuMutu> BakuMutus { get; }

    Task SaveDataAsync(BakuMutu mutu);
}
