using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneers.Domain.Entities;

public class Customer : BaseEntity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public int CityId { get; set; }
    public City City { get; set; } = null!;
    public int CountryId { get; set; }
    public Country Country { get; set; } = null!;
}
