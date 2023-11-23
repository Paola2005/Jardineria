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
    public class PaymentRepository : GenericRepository<Payment>, IPayment
    {
        private readonly JardineriaContext _context;

        public PaymentRepository(JardineriaContext context) : base(context)
        {
            _context = context;
        }
 
        public async Task<IEnumerable<object>> Paypal()
        {
            var paymentsIn2008 = await (
                from payment in _context.Payments
                where payment.PaymentDate.Year == 2008 && payment.Method.MethodPayment1 == "Paypal"
                orderby payment.Total descending
                select new
                {
                    Id = payment.Id,
                    PaymentDate = payment.PaymentDate,
                    MethodId = payment.MethodId, 
                    Method = payment.Method.MethodPayment1, 
                }
            ).ToListAsync();

            return paymentsIn2008;
        } 


 
        public async Task<IEnumerable<object>> GetDistinctPaymentMethods()
        {
            return await (from Method in _context.Methodpayments
                select new{
                    name = Method.MethodPayment1
                }).ToListAsync();
        }


    }
}