using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace GloboTicket.Infrastructure.Platform
{
    public static class DapperServicesExtensions
    {
        public static IServiceCollection AddDapperContext<TContextService>(this IServiceCollection serviceCollection,
            Action<DapperContextOptions> optionsAction)
        {
            serviceCollection.Configure(optionsAction);
            serviceCollection.AddSingleton(typeof(TContextService));

            return serviceCollection;
        }
    }
}
