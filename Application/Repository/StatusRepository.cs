using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;
using Persistence.Data;

namespace Application.Repository
{
    public class StatusRepository : GenericRepository<Status>, IStatus
    {
        private readonly JardineriaContext _context;

        public StatusRepository(JardineriaContext context) : base(context)
        {
            _context = context;
        }
    }
}
