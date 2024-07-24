using AutoMapper;
using GloboTicket.Application.Models;
using GloboTicket.Domain.Entities;
using GloboTicket.Web.Models.Request;

namespace GloboTicket.Web.Platform
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddTicketRequest, TicketModel>();
        }
    }
}
