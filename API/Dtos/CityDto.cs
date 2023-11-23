using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class CityDto
    {
        public int Id { get; set; }
        public string CityName { get; set; }

    public int? StateId { get; set; }

    public virtual ICollection<PostalCode> Postalcodes { get; set; } = new List<PostalCode>();

    }
}
