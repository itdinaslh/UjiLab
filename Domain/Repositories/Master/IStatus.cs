using UjiLab.Domain.Entities;

namespace UjiLab.Domain.Repositories
{
    public interface IStatus
    {
        IQueryable<Status> Statuses { get; }

        Task SaveDataAsync(Status status);
    }
}
