using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneers.Application.DTOs;
public record CountryDto(int Id, string Name);
public record CreateCountryDto(string Name);
public record UpdateCountryDto(int Id, string Name);


