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
    public class OrderRepository : GenericRepository<Order>, IOrder
    {
        private readonly JardineriaContext _context;

        public OrderRepository(JardineriaContext context) : base(context)
        {
            _context = context;
        }
    }
}
