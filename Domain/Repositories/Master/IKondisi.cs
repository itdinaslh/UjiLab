using UjiLab.Domain.Entities;

namespace UjiLab.Domain.Repositories;

public interface IKondisi
{
    IQueryable<Kondisi> Kondisis { get; }

    Task SaveDataAsync(Kondisi kondisi);
}
