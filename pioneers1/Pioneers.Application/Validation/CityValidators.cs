using FluentValidation;
using Pioneers.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneers.Application.Validation;

public class CreateCityDtoValidator : AbstractValidator<CreateCityDto>
{
    public CreateCityDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.CountryId).GreaterThan(0);
    }
}
public class UpdateCityDtoValidator : AbstractValidator<UpdateCityDto>
{
    public UpdateCityDtoValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.CountryId).GreaterThan(0);
    }
}
