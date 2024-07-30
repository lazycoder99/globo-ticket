using AutoMapper;
using GloboTicket.Application.Common.Settings;
using GloboTicket.Application.Contracts.Persistence;
using GloboTicket.Application.Contracts.Services;
using GloboTicket.Application.Models;
using GloboTicket.Application.Models.Http;
using GloboTicket.Domain.Entities;
using System.Net.NetworkInformation;
using System.Reflection;
using GloboTicket.Application.Common.Extensions;
using GloboTicket.Application.Validations;
using GloboTicket.Application.Validations.Extensions;
using Microsoft.Extensions.Logging;

namespace GloboTicket.Application.Features.Tickets
{
    public class TicketService (ILogger<TicketService> logger, IMapper mapper, ITicketRepository ticketRepository) : ITicketService
    {
        public async Task<ResultSet> Get(int ticketId)
        {
            var data = await ticketRepository.Get(ticketId);
            if (data == null)
                return new ResultSet(Error.RecordNotFound);

            return new ResultSet(data, Success.Success);
        }

        public async Task<ResultSet> GetAll()
        {
            var data = await ticketRepository.GetAll();
            var dapperData = await ticketRepository.GetAllWithDapper();

            return new ResultSet(data, Success.Success);
        }

        public async Task<ResultSet> Add(TicketModel ticket)
        {
            logger.LogCallerMemberName();

            var validate = await ticket.Validate(new TicketValidation());
            if (!validate.IsValid)
            {
                logger.LogValidationErrors(validate.Errors);
                return new ResultSet(validate.Errors);
            }

            var entity = mapper.Map<Ticket>(ticket);

            if (entity == null)
            {
                logger.LogWarning($"no mapping found for model, entity is null");
                return new ResultSet(Error.RequestDataIsNull);
            }

            var result = await ticketRepository.Add(entity);
            if (!result)
            {
                logger.LogError($"failed to save ticket {entity.Id}");
                return new ResultSet(Error.Failed);
            }

            return new ResultSet(entity.Id);
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
