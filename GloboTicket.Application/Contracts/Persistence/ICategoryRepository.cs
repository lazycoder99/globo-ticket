using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GloboTicket.Domain.Entities;

namespace GloboTicket.Application.Contracts.Persistence
{
    public interface ICategoryRepository
    {
        public Category Get(int categoryId);
    }
}
