using Entities.DTOs.Concrete.CountryDTO;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.CountryValidator
{
    public class CountryUpdateDTOValidator : AbstractValidator<CountryUpdateDTO>
    {
        public CountryUpdateDTOValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage($"");
            RuleFor(c => c.CountryName).NotEmpty().WithMessage($"");
            RuleFor(c => c.CountryName).MaximumLength(30).WithMessage($"");
            RuleFor(c => c.CountryCode).NotEmpty().WithMessage($"");
            RuleFor(c => c.CountryCode).MaximumLength(30).WithMessage($"");
        }
    }
}