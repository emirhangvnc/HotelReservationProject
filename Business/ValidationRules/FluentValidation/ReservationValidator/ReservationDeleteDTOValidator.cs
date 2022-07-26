using Entities.DTOs.Concrete.ReservationDTO;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.ReservationValidator
{
    public class ReservationDeleteDTOValidator : AbstractValidator<ReservationDeleteDTO>
    {
        public ReservationDeleteDTOValidator()
        {
            RuleFor(r => r.Id).NotEmpty().WithMessage($"");
        }
    }
}