using UjiLab.Domain.Entities;

namespace UjiLab.Domain.Repositories;

public interface IMetodeSampling
{
    IQueryable<MetodeSampling> MetodeSamplings { get; }

    Task SaveDataAsync(MetodeSampling metodeSampling);
}
