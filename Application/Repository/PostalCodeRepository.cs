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
    public class PostalCodeRepository : GenericRepository<PostalCode>, IPostalCode
    {
        private readonly JardineriaContext _context;

        public PostalCodeRepository(JardineriaContext context) : base(context)
        {
            _context = context;
        }
    }
}
