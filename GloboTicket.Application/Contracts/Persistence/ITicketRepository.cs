using System.Collections;
using GloboTicket.Application.Models;
using GloboTicket.Domain.Entities;

namespace GloboTicket.Application.Contracts.Persistence
{
    public interface ITicketRepository
    {
        public Task<Ticket?> Get(int ticketId);
        public Task<List<TicketModel>> GetAll();
        public Task<List<TicketModel>> GetAllWithDapper();

        public Task<bool> Add(Ticket ticket);
        public Task<bool> Update(Ticket ticket);
        public Task<bool> Upsert(Ticket ticket);
        public Task<bool> Delete(Ticket ticket);
    }
}