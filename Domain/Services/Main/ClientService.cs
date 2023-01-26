using UjiLab.Data;
using UjiLab.Domain.Entities;
using UjiLab.Domain.Repositories;

namespace UjiLab.Domain.Services;

public class ClientService : IClient
{
    private readonly AppDbContext context;

    public ClientService(AppDbContext context) { this.context = context; }

    public IQueryable<Client> Clients => context.Clients;

    public async Task StoreDataAsync(Client client)
    {
        await context.Clients.AddAsync(client);
    }
}
