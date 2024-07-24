using GloboTicket.Application.Contracts.Persistence;
using GloboTicket.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GloboTicket.Infrastructure.Platform
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            // register all services

            services.AddDbContext<GloboTicketContext>(options =>
                options.UseInMemoryDatabase("GloboTicket"));

            //services.AddDbContext<GloboTicketContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("GloboTicket")));

            services.AddScoped<ITicketRepository, TicketRepository>();

            return services;
        }
    }
}
