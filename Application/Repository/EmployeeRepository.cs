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
    public class EmployeeRepository : GenericRepository<Employee>, IEmployee
    {
        private readonly JardineriaContext _context;

        public EmployeeRepository(JardineriaContext context) : base(context)
        {
            _context = context;
        }
    }
}
