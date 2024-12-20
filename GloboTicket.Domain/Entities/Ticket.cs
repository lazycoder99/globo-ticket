﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GloboTicket.Domain.Common;

namespace GloboTicket.Domain.Entities
{
    [Table("Tickets")]
    public class Ticket : AuditableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public int ClientId { get; set; } // Foreign key

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
