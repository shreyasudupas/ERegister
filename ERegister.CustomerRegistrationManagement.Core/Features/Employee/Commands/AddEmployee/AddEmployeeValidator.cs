using FluentValidation;

namespace ERegister.CustomerRegistrationManagement.Core.Features.Employee.Commands.AddEmployee
{
    public  class AddEmployeeValidator : AbstractValidator<AddEmployeeCommand>
    {
        public AddEmployeeValidator()
        {
            RuleFor(p => p.Firstname)
                .NotEmpty().WithMessage("Firstname is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} should not exceed 50 characters");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("LastName is required")
                .NotNull();

            RuleFor(p => p.Address)
                .NotEmpty().WithMessage("Address is required")
                .NotNull();
        }
    }
}
