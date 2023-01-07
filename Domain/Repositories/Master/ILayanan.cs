using UjiLab.Domain.Entities;

namespace UjiLab.Domain.Repositories;

public interface ILayanan
{
    IQueryable<Layanan> Layanans { get; }

    Task SaveDataAsync(Layanan layanan);
}
