using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneers.Domain.Entities;

public class City : BaseEntity
{
    public string Name { get; set; } = null!;
    public int CountryId { get; set; }
    public Country Country { get; set; } = null!;
    public ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
