using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using GloboTicket.Domain.Common;
using GloboTicket.Domain.Entities;

namespace GloboTicket.Infrastructure.Platform
{
    public class GloboTicketContext(DbContextOptions<GloboTicketContext> options) : DbContext(options)
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public override int SaveChanges()
        {
            PerformEntityOperations();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            PerformEntityOperations();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void PerformEntityOperations()
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
    }
}
