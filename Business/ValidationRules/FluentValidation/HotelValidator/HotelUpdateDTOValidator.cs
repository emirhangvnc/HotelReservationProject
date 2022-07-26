using Entities.DTOs.Concrete.HotelDTO;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.HotelValidator
{
    public class HotelUpdateDTOValidator : AbstractValidator<HotelUpdateDTO>
    {
        public HotelUpdateDTOValidator()
        {
            RuleFor(h => h.Id).NotEmpty().WithMessage($"");
            RuleFor(h => h.CityId).NotEmpty().WithMessage($"");
            RuleFor(h => h.HotelName).NotEmpty().WithMessage($"");
            RuleFor(h => h.HotelName).MaximumLength(30).WithMessage($"");
            RuleFor(h => h.PhoneNumber).NotEmpty().WithMessage($"");
            RuleFor(h => h.PhoneNumber).MaximumLength(20).WithMessage($"");
            RuleFor(h => h.Address).NotEmpty().WithMessage($"");
            RuleFor(h => h.Address).MaximumLength(60).WithMessage($"");
        }
    }
}