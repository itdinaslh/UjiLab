using UjiLab.Domain.Entities;

namespace UjiLab.Domain.Repositories;

public interface IClient
{
    IQueryable<Client> Clients { get; }

    Task StoreDataAsync(Client client);
}
