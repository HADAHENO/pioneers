using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneers.Domain.Entities;

public class Country : BaseEntity
{
    public string Name { get; set; } = null!;
    public ICollection<City> Cities { get; set; } = new List<City>();
    public ICollection<Customer> Customers { get; set; } = new List<Customer>();
}

