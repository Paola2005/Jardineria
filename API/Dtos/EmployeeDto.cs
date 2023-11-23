
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class EmployeeDto
    {
    public int PersonId { get; set; }
    public string Extention { get; set; }
    public string OfficeCode { get; set; }

    public int? ManagerCode { get; set; }
    public  ICollection<Client> Clients { get; set; } = new List<Client>();  
  
    }
}
