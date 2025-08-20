using FluentValidation;
using Pioneers.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pioneers.Application.Validation;

public class CreateCountryDtoValidator : AbstractValidator<CreateCountryDto>
{
    public CreateCountryDtoValidator() => RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
}
public class UpdateCountryDtoValidator : AbstractValidator<UpdateCountryDto>
{
    public UpdateCountryDtoValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
    }
}
