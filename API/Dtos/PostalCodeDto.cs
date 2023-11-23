
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class PostalCodeDto
    {
        public int Id { get; set; }
public string PostalCode1 { get; set; }

    public int? CityId { get; set; }

    public virtual City City { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<Office> Offices { get; set; } = new List<Office>();
    }
}
