using UjiLab.Domain.Entities;

namespace UjiLab.Domain.Repositories;

public interface IBakuMutu
{
    IQueryable<JenisBakuMutu> JenisBakuMutus { get; }

    IQueryable<BakuMutu> BakuMutus { get; }

    Task SaveJenisAsync(JenisBakuMutu jenis);

    Task SaveBakuMutuAsync(BakuMutu mutu);
}
