using UjiLab.Data;
using UjiLab.Domain.Entities;
using UjiLab.Domain.Repositories;
using UjiLab.Models;

namespace UjiLab.Domain.Services;

public class ClientService : IClient
{
    private readonly AppDbContext context;

    public ClientService(AppDbContext context) { this.context = context; }

    public IQueryable<Client> Clients => context.Clients;

    public async Task StoreDataAsync(Client client)
    {
        await context.Clients.AddAsync(client);

        await context.SaveChangesAsync();
    }

    public async Task VerifyClient(ClientDetailsVM model)
    {
        Client? data = await context.Clients.FindAsync(model.ClientID);

        if (data is not null)
        {
            data.StatusID = model.StatusID;
            data.Keterangan = model.Keterangan;
            if (model.StatusID == 2)
            {
                data.IsVerified = true;
            }

            context.Clients.Update(data);
        }

        await context.SaveChangesAsync();
    }
}
