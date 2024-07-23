using GloboTicket.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GloboTicket.Application.Models;
using GloboTicket.Application.Models.Http;

namespace GloboTicket.Application.Contracts.Services
{
    public interface ITicketService
    {
        public Task<ResultSet> Get(int ticketId);
        public Task<ResultSet> GetAll();

        public Task<ResultSet> Add(TicketModel ticket);
        public Task<ResultSet> Update(TicketModel ticket);
        public Task<ResultSet> Upsert(TicketModel ticket);
        public Task<ResultSet> Delete(int ticketId);
    }
}
