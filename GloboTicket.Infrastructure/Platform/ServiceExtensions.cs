using Microsoft.Extensions.DependencyInjection;

namespace GloboTicket.Infrastructure.Platform
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            // register all services

            services.AddDbContext<ApiGatewayContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("APIGatewayService")));

            services.AddDbContext<ApiUrlContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("APIGatewayUrl")));

            services.AddDbContext<PerceptContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Percept")));

            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddSingleton<AppConfigService>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IConsumerRepository, ConsumerRepository>();
            services.AddScoped<IInstrumentRepository, InstrumentRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IVisaCardService, VisaCardService>();
            services.AddScoped<IMessagingRepository, MessagingRepository>();
            services.AddScoped<IPerceptRepository, PerceptRepository>();

            services.AddScoped<IVisaDirectProvider, VisaDirectProvider>();
            //services.AddScoped<IPlugProvider, PlugProvider>();
            services.AddScoped<IACHProvider, ACHProvider>();
            services.AddScoped<IUrlRepository, UrlRepository>();
            services.AddScoped<IBGServiceRepository, BGServiceRepository>();

            return services;
        }
    }
}
