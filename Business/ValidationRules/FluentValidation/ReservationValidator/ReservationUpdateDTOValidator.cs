using Entities.DTOs.Concrete.ReservationDTO;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.ReservationValidator
{
    public class ReservationUpdateDTOValidator : AbstractValidator<ReservationUpdateDTO>
    {
        public ReservationUpdateDTOValidator()
        {
            RuleFor(r => r.Id).NotEmpty().WithMessage($"");
            RuleFor(r => r.UserId).NotEmpty().WithMessage($"");
            RuleFor(r => r.RoomId).NotEmpty().WithMessage($"");
            RuleFor(r => r.UserNumber).NotEmpty().WithMessage($"");
            RuleFor(r => r.Checkin).NotEmpty().WithMessage($"");
            RuleFor(r => r.Checkout).NotEmpty().WithMessage($"");
        }
    }
}