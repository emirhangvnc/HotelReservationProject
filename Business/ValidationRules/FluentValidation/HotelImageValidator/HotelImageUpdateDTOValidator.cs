using Entities.DTOs.Concrete.HotelImageDTO;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.HotelImageValidator
{
    public class HotelImageUpdateDTOValidator : AbstractValidator<HotelImageUpdateDTO>
    {
        public HotelImageUpdateDTOValidator()
        {
            RuleFor(h => h.Id).NotEmpty().WithMessage($"");
            RuleFor(h => h.HotelId).NotEmpty().WithMessage($"");
        }
    }
}