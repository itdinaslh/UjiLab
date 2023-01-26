using UjiLab.Data;
using UjiLab.Domain.Entities;
using UjiLab.Domain.Repositories;

namespace UjiLab.Domain.Services
{
    public class StatusService : IStatus
    {
        private readonly AppDbContext context;

        public StatusService(AppDbContext context) { this.context = context; }

        public IQueryable<Status> Statuses => context.Statuses;

        public async Task SaveDataAsync(Status status)
        {
            if (status.StatusID == 0)
            {
                await context.Statuses.AddAsync(status);
            } else
            {
                Status? data = await context.Statuses.FindAsync(status.StatusID);

                if (data is not null)
                {
                    data.StatusName = status.StatusName;
                    data.UpdatedAt = DateTime.Now;

                    context.Update(data);
                }
            }

            await context.SaveChangesAsync();
        }
    }
}
