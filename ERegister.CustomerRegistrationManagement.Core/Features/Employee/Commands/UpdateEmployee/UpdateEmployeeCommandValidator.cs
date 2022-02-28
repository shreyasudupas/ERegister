using FluentValidation;

namespace ERegister.CustomerRegistrationManagement.Core.Features.Employee.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(e => e.EmployeeId)
                .GreaterThan(0).WithMessage("EmployeeId must be grater than 0");
        }
    }
}
