using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GloboTicket.Application.Contracts.Persistence;
using GloboTicket.Domain.Entities;

namespace GloboTicket.Infrastructure.Persistence
{
    internal class ClientRepository : IClientRepository
    {
        public Task<Client> Get(int clientId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Add(Client client)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExist(string mobileNumber)
        {
            throw new NotImplementedException();
        }
    }
}
