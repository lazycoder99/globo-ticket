using GloboTicket.Application.Contracts.Services;
using GloboTicket.Domain.Entities;

namespace GloboTicket.Application.Features.Tickets
{
    public class TicketService : ITicketService
    {
        public Ticket Get(int ticketId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Ticket>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Add(Ticket ticket)
        {
            throw new NotImplementedException();
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
