using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class SupplierDto
    {

public int Id { get; set; }
public string Name { get; set; }

    public string Phone { get; set; }

    public string Fax { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}

