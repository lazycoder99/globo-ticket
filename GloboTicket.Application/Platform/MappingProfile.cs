using AutoMapper;
using GloboTicket.Application.Models;
using GloboTicket.Domain.Entities;

namespace GloboTicket.Application.Platform
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TicketModel, Ticket>();
        }
    }
}
