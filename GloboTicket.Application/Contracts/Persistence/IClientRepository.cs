using GloboTicket.Domain.Entities;

namespace GloboTicket.Application.Contracts.Persistence
{
    public interface IClientRepository
    {
        public Task<Client> Get(int clientId);
        public Task<bool> Add(Client client);
        public Task<bool> IsExist(string mobileNumber);
    }
}