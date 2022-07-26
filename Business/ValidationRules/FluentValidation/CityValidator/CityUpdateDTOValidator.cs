using Entities.DTOs.Concrete.CityDTO;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.CityValidator
{
    public class CityUpdateDTOValidator : AbstractValidator<CityUpdateDTO>
    {
        public CityUpdateDTOValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage($"");
            RuleFor(c => c.CountryId).NotEmpty().WithMessage($"");
            RuleFor(c => c.CityName).NotEmpty().WithMessage($"");
            RuleFor(c => c.CityName).MaximumLength(30).WithMessage($"");
            RuleFor(c => c.CityCode).NotEmpty().WithMessage($"");
            RuleFor(c => c.CityCode).MaximumLength(30).WithMessage($"");
        }
    }
}