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
    public class ProductRepository : GenericRepositoryS<Product>, IProduct
    {
        private readonly JardineriaContext _context;

        public ProductRepository(JardineriaContext context) : base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<object>> GetProductsNoOrderWithInfo()
        {
            return await (from product in _context.Products
                            join OrderDetail in _context.Orderdetails on product.Id equals OrderDetail.ProductCode into OrderDetailGroup
                            from subOrderDetail in OrderDetailGroup.DefaultIfEmpty()
                            join ProductLine in _context.Productlines on product.ProductLine equals ProductLine.Id
                            where subOrderDetail == null
                            select new {
                                nombre = product.Name,
                                description = product.Description,
                                image = ProductLine.Image
                                })
                            .ToListAsync();
        }




   
        public List<object> GetProductRangesPerClient()
        {
            var productRangesPerClient = from order in _context.Orders
                                        from orderDetail in _context.Orderdetails
                                        from product in _context.Products
                                        from productLine in _context.Productlines
                                        where order.Id == orderDetail.OrderId && orderDetail.ProductCode == product.Id && product.ProductLineNavigation.ProductLine1 == productLine.ProductLine1
                                        group new { productLine.DescriptionText, product.ProductLineNavigation.ProductLine1 } by new { order.ClientCodeNavigation.PersonId, order.ClientCodeNavigation.ClientName } into groupedProducts
                                        select new
                                        {
                                            ClientName = groupedProducts.Key.ClientName,
                                            PersonId = groupedProducts.Key.PersonId,
                                            ProductRanges = groupedProducts.Select(p => new { p.DescriptionText, p.ProductLine1 }).Distinct().ToList()
                                        };

            return productRangesPerClient.ToList<object>();
        }


    }
}