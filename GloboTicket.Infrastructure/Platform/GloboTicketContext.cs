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
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.Id); // Setting the primary key
                entity.Property(e => e.Id).UseIdentityColumn(); // For SQL Server

                // For other database providers, you may use:
                // .ValueGeneratedOnAdd();
            });
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
