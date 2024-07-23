using System.Collections;
using GloboTicket.Domain.Entities;

namespace GloboTicket.Application.Contracts.Persistence
{
    public interface ITicketRepository
    {
        public Ticket Get(int ticketId);
        public Task<ICollection> GetAll();

        public Task<bool> Add(Ticket ticket);
        public Task<bool> Update(Ticket ticket);
        public Task<bool> Upsert(Ticket ticket);
        public Task<bool> Delete(Ticket ticket);
    }
}