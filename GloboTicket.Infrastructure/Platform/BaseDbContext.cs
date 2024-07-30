using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using GloboTicket.Domain.Common;
using Microsoft.Data.SqlClient;
using System.Data;

namespace GloboTicket.Infrastructure.Platform
{
    public class BaseDbContext(DbContextOptions<GloboTicketContext> options, IConfiguration configuration)
        : DbContext(options)
    {
        private readonly string? _connectionString = configuration.GetConnectionString("GloboTicket");

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        #region Override Methods ********************************************************************

        public override int SaveChanges()
        {
            DoBeforeUpsert();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            DoBeforeUpsert();
            return base.SaveChangesAsync(cancellationToken);
        }

        #endregion

        #region Private Methods *********************************************************************

        private void DoBeforeUpsert()
        {
            try
            {
                foreach (var entry in ChangeTracker.Entries())
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            break;
                        case EntityState.Modified:
                            ((AuditableEntity)entry.Entity).UpdatedAt = DateTime.UtcNow;
                            break;
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        #endregion
    }
}
