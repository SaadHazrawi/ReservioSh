using FluentValidation;
using Reservio.DTOS.Clinic;

namespace Reservio.Validation
{
    public class ClinicDtoValidator : AbstractValidator<ClinicCreationDTO>
    {
        public ClinicDtoValidator()
        {
            RuleFor(n => n.Name)
                .NotNull().WithMessage("The Name Clinic cannot be null or empty.")
                .MaximumLength(50).WithMessage("The Name Clinic cannot be greater than 50 characters.")
                .MinimumLength(2).WithMessage("The Name Clinic cannot be less than 2 characters.");
        }
    }
}
