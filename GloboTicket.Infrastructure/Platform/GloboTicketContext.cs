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
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace GloboTicket.Infrastructure.Platform
{
    public class GloboTicketContext(DbContextOptions<GloboTicketContext> options, IConfiguration configuration) : DbContext(options)
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Client> Clients { get; set; }

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
    }
}
