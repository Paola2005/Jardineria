using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
        
namespace Domain.Interfaces
{
    public interface IClient:IGenericRepository<Client>
    {
        List<object> GetClientsWithPaymentsAndRepresentativesWithCity();
        List<Client> GetClientsWithoutPayments();
        List<object> GetClientsWithRepresentativesAndOfficeCity();
        IEnumerable<object> GetUniqueClientCodesWithPaymentsIn2008();
        List<object> GetClientsWithoutPaymentsAndRepresentativesWithCity();
    }
}
