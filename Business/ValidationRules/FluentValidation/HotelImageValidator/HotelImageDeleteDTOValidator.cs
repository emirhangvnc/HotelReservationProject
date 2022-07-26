using Entities.DTOs.Concrete.HotelImageDTO;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.HotelImageValidator
{
    public class HotelImageDeleteDTOValidator : AbstractValidator<HotelImageDeleteDTO>
    {
        public HotelImageDeleteDTOValidator()
        {
            RuleFor(h => h.Id).NotEmpty().WithMessage($"");
        }
    }
}