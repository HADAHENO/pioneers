using AutoMapper;
using Pioneers.Application.DTOs;
using Pioneers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneers.Application.Mapping;

public class Profiles : Profile
{
    public Profiles()
    {
        CreateMap<Country, CountryDto>();
        CreateMap<CreateCountryDto, Country>();
        CreateMap<UpdateCountryDto, Country>();

        CreateMap<City, CityDto>()
            .ForCtorParam("CountryName", opt => opt.MapFrom(s => s.Country.Name));
        CreateMap<CreateCityDto, City>();
        CreateMap<UpdateCityDto, City>();

        CreateMap<Customer, CustomerDto>()
            .ForCtorParam("CityName", opt => opt.MapFrom(s => s.City.Name))
            .ForCtorParam("CountryName", opt => opt.MapFrom(s => s.Country.Name));
        CreateMap<CreateCustomerDto, Customer>();
        CreateMap<UpdateCustomerDto, Customer>();
    }
}
