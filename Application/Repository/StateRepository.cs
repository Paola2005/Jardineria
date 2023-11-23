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
    public class StateRepository : GenericRepository<State>, IState
    {
        private readonly JardineriaContext _context;

        public StateRepository(JardineriaContext context) : base(context)
        {
            _context = context;
        }
    }
}
