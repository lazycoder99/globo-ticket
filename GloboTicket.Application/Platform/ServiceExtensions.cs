using GloboTicket.Application.Contracts.Services;
using GloboTicket.Application.Features.Clients;
using GloboTicket.Application.Features.Tickets;
using Microsoft.Extensions.DependencyInjection;

namespace GloboTicket.Application.Platform
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // register all services
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ITicketService, TicketService>();

            return services;
        }
    }
}
