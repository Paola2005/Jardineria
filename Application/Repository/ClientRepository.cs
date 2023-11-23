using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class ClientRepository : GenericRepository<Client>, IClient
    {
        private readonly JardineriaContext _context;

        public ClientRepository(JardineriaContext context) : base(context)
        {
            _context = context;
        }



        public IEnumerable<object> GetUniqueClientCodesWithPaymentsIn2008()
        {
            var clientCodesWithPaymentsIn2008 = _context.Payments
                .Where(payment => payment.PaymentDate.Year == 2008)
                .Select(payment => new { ClientCode = payment.IdNavigation.PersonId })
                .Distinct()
                .OrderBy(clientDetails => clientDetails.ClientCode);

            return clientCodesWithPaymentsIn2008;
        }




        public List<Client> GetClientsWithoutPayments()
        {
            var clientsWithoutPayments = from client in _context.Clients
                                            where !_context.Payments.Any(payment => payment.Id == client.PersonId)
                                            select client;

            return clientsWithoutPayments.ToList();
        }



         public List<object> GetClientsWithoutPaymentsAndRepresentativesWithCity()
        {
            var clientsWithoutPayments = _context.Clients
                .Where(client => !client.Payments.Any())
                .Select(client => new
                {
                    ClientName = client.ClientName,
                    RepresentativeName = $"{client.CodEmployeeNavigation.Person.FirstName} {client.CodEmployeeNavigation.Person.LastName1}",
                    RepresentativeCity = client.CodEmployeeNavigation.Office.PostalCode.City.CityName
                })
                .ToList<object>();

            return clientsWithoutPayments;
        }


        public List<object> GetClientsWithPaymentsAndRepresentativesWithCity()
        {
            var clientsWithPayments = _context.Clients
                .Where(client => client.Payments.Any())
                .Select(client => new
                {
                    ClientName = client.ClientName,
                    RepresentativeName = $"{client.CodEmployeeNavigation.Person.FirstName} {client.CodEmployeeNavigation.Person.LastName1}",
                    RepresentativeCity = client.CodEmployeeNavigation.Office.PostalCode.City.CityName
                })
                .ToList<object>();

            return clientsWithPayments;
        }




        public List<object> GetClientsWithRepresentativesAndOfficeCity()
        {
            var clientsWithRepresentatives = _context.Clients
                .Select(client => new
                {
                    ClientName = client.ClientName,
                    RepresentativeName = $"{client.CodEmployeeNavigation.Person.FirstName} {client.CodEmployeeNavigation.Person.LastName1}",
                    RepresentativeCity = client.CodEmployeeNavigation.Office.PostalCode.City.CityName
                })
                .ToList<object>();

            return clientsWithRepresentatives;
        }








}
}
