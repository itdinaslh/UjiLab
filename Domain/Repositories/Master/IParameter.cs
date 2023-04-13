using UjiLab.Domain.Entities;

namespace UjiLab.Domain.Repositories;

public interface IParameter
{
    IQueryable<Parameter> Parameters { get; }

    IQueryable<JenisParameter> JenisParameters { get; }

    IQueryable<MetodeParameter> MetodeParameters { get; }

    Task SaveDataAsync(Parameter param);

    Task SaveMetodeAsync(MetodeParameter metode);
}
