using Entities.DTOs.Concrete.RoomDTO;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.RoomValidator
{
    public class RoomUpdateDTOValidator : AbstractValidator<RoomUpdateDTO>
    {
        public RoomUpdateDTOValidator()
        {
            RuleFor(r => r.Id).NotEmpty().WithMessage($"");
            RuleFor(r => r.HotelId).NotEmpty().WithMessage($"");
            RuleFor(r => r.Title).NotEmpty().WithMessage($"");
            RuleFor(r => r.Title).MaximumLength(30).WithMessage($"");
            RuleFor(r => r.Description).NotEmpty().WithMessage($"");
            RuleFor(r => r.Description).MaximumLength(70).WithMessage($"");
            RuleFor(r => r.Price).NotEmpty().WithMessage($"");
            RuleFor(r => r.StandartBad).NotEmpty().WithMessage($"");
        }
    }
}