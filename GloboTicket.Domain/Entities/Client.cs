using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GloboTicket.Domain.Common;

namespace GloboTicket.Domain.Entities
{
    public class Client : AuditableEntity
    {
        public int Id { get; set; }
    }
}
