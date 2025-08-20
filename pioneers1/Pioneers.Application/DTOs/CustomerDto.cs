using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneers.Application.DTOs;

public record CustomerDto(
    int Id, string FirstName, string LastName, string Email, string Phone,
    int CityId, string CityName, int CountryId, string CountryName);

public record CreateCustomerDto(
    string FirstName, string LastName, string Email, string Phone, int CityId, int CountryId);

public record UpdateCustomerDto(
    int Id, string FirstName, string LastName, string Email, string Phone, int CityId, int CountryId);
