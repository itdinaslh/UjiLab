using UjiLab.Domain.Entities;
using UjiLab.Models;

namespace UjiLab.Domain.Repositories;

public interface IClient
{
    IQueryable<Client> Clients { get; }

    Task StoreDataAsync(Client client);

    Task VerifyClient(ClientDetailsVM model);
}
