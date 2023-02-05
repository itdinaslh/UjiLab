using UjiLab.Domain.Entities;

namespace UjiLab.Domain.Repositories;

public interface ITipePengajuan
{
    IQueryable<TipePengajuan> TipePengajuans { get; }

    Task SaveDataAsync(TipePengajuan tipe);
}
