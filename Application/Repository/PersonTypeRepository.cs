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
    public class PersonTypeRepository : GenericRepository<PersonType>, IPersonType
    {
        private readonly JardineriaContext _context;

        public PersonTypeRepository(JardineriaContext context) : base(context)
        {
            _context = context;
        }
    }
}
