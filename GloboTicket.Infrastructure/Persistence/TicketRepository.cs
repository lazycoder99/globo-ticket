using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GloboTicket.Application.Contracts.Persistence;
using GloboTicket.Application.Models;
using GloboTicket.Domain.Entities;
using GloboTicket.Infrastructure.Platform;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.Infrastructure.Persistence
{
    internal class TicketRepository (GloboTicketContext dbo, DapperContext dapper) : ITicketRepository
    {
        public async Task<Ticket?> Get(int ticketId)
        {
            return await dbo.Tickets.FindAsync(ticketId);
        }

        public async Task<List<TicketModel>> GetAll()
        {
            var query = from t in dbo.Tickets
                join c in dbo.Clients on t.ClientId equals c.Id
                select new TicketModel
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    ClientId = c.Id,
                    ClientName = c.Name,
                    CreatedAt = t.CreatedAt,
                    UpdatedAt = t.UpdatedAt,
                };

            //var sql = query.ToQueryString();
            return await query.ToListAsync();
        }

        public async Task<List<TicketModel>> GetAllWithDapper()
        {
            using var connection = dapper.CreateConnection();

            var sql = "SELECT * FROM Tickets";
            var data = await connection.QueryAsync<TicketModel>(sql);

            return data.ToList();
        }

        public async Task<List<TicketModel>> GetAllWithSpDapper()
        {
            using var connection = dapper.CreateConnection();

            //var sql = "SELECT * FROM Tickets";
            var data = await connection.QueryAsync<TicketModel>("GetAllTickets",
                commandType: CommandType.StoredProcedure);

            return data.ToList();
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
