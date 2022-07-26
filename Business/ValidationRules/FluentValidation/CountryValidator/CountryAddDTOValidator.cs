using Entities.DTOs.Concrete.CountryDTO;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.CountryValidator
{
    public class CountryAddDTOValidator : AbstractValidator<CountryAddDTO>
    {
        public CountryAddDTOValidator()
        {
            RuleFor(c => c.CountryName).NotEmpty().WithMessage($"");
            RuleFor(c => c.CountryName).MaximumLength(30).WithMessage($"");
            RuleFor(c => c.CountryCode).NotEmpty().WithMessage($"");
            RuleFor(c => c.CountryCode).MaximumLength(30).WithMessage($"");
        }
    }
}