using GloboTicket.Application.Platform;
using GloboTicket.Infrastructure.Platform;
using GloboTicket.Web.Middleware;
using Microsoft.OpenApi.Models;

namespace GloboTicket.Web.Platform
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    policyBuilder =>
                    {
                        policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    });
            });

            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();

            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddApplicationServices();
            builder.Services.AddHttpClient();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GloboTicket", Version = "v1" });
            });

            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowAllOrigins");

            // Register the global error handling middleware first
            app.UseExceptionHandler();

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "GloboTicket"); });

            //app.UseSerilogRequestLogging();
            app.UseMiddleware<ValidationMiddleware>();

            app.UseAuthorization();
            app.MapControllers();

            return app;
        }

    }
}
