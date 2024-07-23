using GloboTicket.Application.Contracts.Services;
using GloboTicket.Domain.Entities;

namespace GloboTicket.Application.Features.Clients
{
    public class ClientService : IClientService
    {
        public Task<Client> Get(int clientId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Add(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
