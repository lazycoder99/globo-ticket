using GloboTicket.Application.Contracts.Services;
using GloboTicket.Application.Features.Tickets;
using Microsoft.Extensions.DependencyInjection;

namespace GloboTicket.Application.Platform
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            // register all services
            services.AddScoped<ITicketService, TicketService>();

            return services;
        }
    }
}
