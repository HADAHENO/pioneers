using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneers.Application.DTOs;

public record CityDto(int Id, string Name, int CountryId, string CountryName);
public record CreateCityDto(string Name, int CountryId);
public record UpdateCityDto(int Id, string Name, int CountryId);
