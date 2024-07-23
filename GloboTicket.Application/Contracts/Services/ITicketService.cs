using GloboTicket.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.Application.Contracts.Services
{
    public interface ITicketService
    {
        public Ticket Get(int ticketId);
        public Task<ICollection<Ticket>> GetAll();

        public Task<bool> Add(Ticket ticket);
        public Task<bool> Update(Ticket ticket);
        public Task<bool> Upsert(Ticket ticket);
        public Task<bool> Delete(Ticket ticket);
    }
}
