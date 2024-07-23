using GloboTicket.Application.Contracts.Persistence;
using GloboTicket.Application.Contracts.Services;
using GloboTicket.Application.Models;
using GloboTicket.Application.Models.Http;
using GloboTicket.Domain.Entities;

namespace GloboTicket.Application.Features.Tickets
{
    public class TicketService (ITicketRepository ticketRepository) : ITicketService
    {
        public async Task<ResultSet> Get(int ticketId)
        {
            var data = await ticketRepository.Get(ticketId);
            var resultSet = new ResultSet(data);
            return resultSet;
        }

        Task<ResultSet> ITicketService.GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResultSet> Add(TicketModel ticket)
        {
            throw new NotImplementedException();
        }

        public Task<ResultSet> Update(TicketModel ticket)
        {
            throw new NotImplementedException();
        }

        public Task<ResultSet> Upsert(TicketModel ticket)
        {
            throw new NotImplementedException();
        }

        public Task<ResultSet> Delete(int ticketId)
        {
            throw new NotImplementedException();
        }
    }
}
