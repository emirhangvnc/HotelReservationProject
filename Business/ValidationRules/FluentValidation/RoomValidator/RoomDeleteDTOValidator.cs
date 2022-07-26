using Entities.DTOs.Concrete.RoomDTO;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.RoomValidator
{
    public class RoomDeleteDTOValidator : AbstractValidator<RoomDeleteDTO>
    {
        public RoomDeleteDTOValidator()
        {
            RuleFor(h => h.Id).NotEmpty().WithMessage($"");
        }
    }
}