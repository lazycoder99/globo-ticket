using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GloboTicket.Application.Contracts.Persistence;
using GloboTicket.Domain.Entities;
using GloboTicket.Infrastructure.Platform;

namespace GloboTicket.Infrastructure.Persistence
{
    internal class TicketRepository (GloboTicketContext dbo) : ITicketRepository
    {
        public Task<Ticket> Get(int ticketId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Add(Ticket ticket)
        {
            dbo.Tickets.Add(ticket);
            var r = await dbo.SaveChangesAsync();
            return r > 0;
        }

        public Task<bool> Update(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Upsert(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
