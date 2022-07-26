using Entities.DTOs.Concrete.CityDTO;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.CityValidator
{
    public class CityDeleteDTOValidator : AbstractValidator<CityDeleteDTO>
    {
        public CityDeleteDTOValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage($"");
        }
    }
}