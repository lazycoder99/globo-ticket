using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.Common;
using Microsoft.Extensions.Options;

namespace GloboTicket.Infrastructure.Platform
{
    public class DapperContext(IOptions<DapperContextOptions> options)
    {
        public IDbConnection CreateConnection()
        {
            if (options.Value.Connection == null)
                throw new NotSupportedException($"The database type is not supported.");

            return options.Value.Connection;
        }
    }

    public class DapperContextOptions
    {
        public IDbConnection? Connection { get; private set; }

        public void UseSqlServer(string? connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new NullReferenceException();

            Connection = new SqlConnection(connectionString);
        }

        public void UseMySql(string? connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new NullReferenceException();

            Connection = new MySqlConnection(connectionString);
        }

        public void UseNpgsql(string? connectionString)
        {
            throw new NotImplementedException();
        }

        public void UseSqlite(string? connectionString)
        {
            throw new NotImplementedException();
        }
        public void UseOracle(string? connectionString)
        {
            throw new NotImplementedException();
        }
        public void UseFirebird(string? connectionString)
        {
            throw new NotImplementedException();
        }
    }
}
