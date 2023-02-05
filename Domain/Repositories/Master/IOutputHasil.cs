using UjiLab.Domain.Entities;

namespace UjiLab.Domain.Repositories;

public interface IOutputHasil
{
    IQueryable<OutputHasil> OutputHasils { get; }

    Task SaveDataAsync(OutputHasil output);
}
