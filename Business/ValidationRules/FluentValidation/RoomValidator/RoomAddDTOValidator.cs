using Entities.DTOs.Concrete.RoomDTO;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.RoomValidator
{
    public class RoomAddDTOValidator : AbstractValidator<RoomAddDTO>
    {
        public RoomAddDTOValidator()
        {
            RuleFor(h => h.HotelId).NotEmpty().WithMessage($"");
            RuleFor(h => h.Title).NotEmpty().WithMessage($"");
            RuleFor(h => h.Title).MaximumLength(30).WithMessage($"");
            RuleFor(h => h.Description).NotEmpty().WithMessage($"");
            RuleFor(h => h.Description).MaximumLength(70).WithMessage($"");
            RuleFor(h => h.Price).NotEmpty().WithMessage($"");
            RuleFor(h => h.StandartBad).NotEmpty().WithMessage($"");
        }
    }
}