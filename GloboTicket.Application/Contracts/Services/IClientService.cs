using GloboTicket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.Application.Contracts.Services
{
    public interface IClientService
    {
        public Task<Client> Get(int clientId);
        public Task<bool> Add(Client client);
    }
}
