using Entities.DTOs.Concrete.CountryDTO;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.CountryValidator
{
    public class CountryDeleteDTOValidator : AbstractValidator<CountryDeleteDTO>
    {
        public CountryDeleteDTOValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage($"");
        }
    }
}