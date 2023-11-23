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
    public class EmployeeRepository : GenericRepository<Employee>, IEmployee
    {
        private readonly JardineriaContext _context;

        public EmployeeRepository(JardineriaContext context)
            : base(context)
        {
            _context = context;
        }



        public List<object> GetEmployeeHierarchy()
        {
            var employeeHierarchy = from employee in _context.Employees
                                    join manager in _context.Employees on employee.ManagerCode equals manager.PersonId into managers
                                    from manager in managers.DefaultIfEmpty()
                                    join grandManager in _context.Employees on manager.ManagerCode equals grandManager.PersonId into grandManagers
                                    from grandManager in grandManagers.DefaultIfEmpty()
                                    select new
                                    {
                                EmployeeName = employee.Person.FirstName + " " + employee.Person.LastName1,
                                ManagerName = manager != null ? manager.Person.FirstName + " " + manager.Person.LastName1 : null,
                                GrandManagerName = grandManager != null ? grandManager.Person.FirstName + " " + grandManager.Person.LastName1 : null
                                    };

            return employeeHierarchy.Cast<object>().ToList();
        } 
}
}
       
