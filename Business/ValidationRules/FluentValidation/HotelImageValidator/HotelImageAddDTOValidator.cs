using Entities.DTOs.Concrete.HotelImageDTO;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.HotelImageValidator
{
    public class HotelImageAddDTOValidator : AbstractValidator<HotelImageAddDTO>
    {
        public HotelImageAddDTOValidator()
        {
            RuleFor(h => h.HotelId).NotEmpty().WithMessage($"");
        }
    }
}