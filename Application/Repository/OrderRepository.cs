using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;

namespace Application.Repository
{
    public class OrdersRepository : GenericRepository<Order>, IOrder
    {
        private readonly JardineriaContext _context;

        public OrdersRepository(JardineriaContext context) : base(context)
        {
            _context = context;
        }

      
        public async Task<IEnumerable<object>> PedidosEstado()
        {
            return await (from order in _context.Orders
                        join client in _context.Clients on order.ClientCode equals client.Id
                        join postalCode in _context.Postalcodes on client.PostalCodeId equals postalCode.Id
                        join city in _context.Cities on postalCode.CityId equals city.Id
                        join state in _context.States on city.StateId equals state.Id
                        group order by state.Id into groupedOrders
                        orderby groupedOrders.Count() descending
                        select new
                        {
                            State = groupedOrders.Key,
                            NumberOfOrders = groupedOrders.Count()
                        }).ToListAsync();
        }
    }
}