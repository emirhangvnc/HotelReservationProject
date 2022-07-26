using Entities.DTOs.Concrete.HotelDTO;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.HotelValidator
{
    public class HotelDeleteDTOValidator : AbstractValidator<HotelDeleteDTO>
    {
        public HotelDeleteDTOValidator()
        {
            RuleFor(h => h.Id).NotEmpty().WithMessage($"");
        }
    }
}