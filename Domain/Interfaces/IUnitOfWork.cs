using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
        
namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {

        ICity Cities { get; }
        IClient Clients { get; }
        ICountry Countries { get; }
        IEmployee Employees { get; }
        IMethodPayment Methods { get; }
        IOffice Offices { get; }
        IOrderDetail Details { get; }
        IOrder Orderse { get; }
        IPayment Payments { get; }
        IPersonType PTypes { get; }
        IPerson Persons { get; }
        IPostalCode PCodes { get; }
        IProductLine PLines { get; }
        IProduct Products { get; }
        IState States { get; }
        IStatus Status { get; }
        ISupplier Suppliers { get; }
        Task<int> SaveAsync();
    }
}
