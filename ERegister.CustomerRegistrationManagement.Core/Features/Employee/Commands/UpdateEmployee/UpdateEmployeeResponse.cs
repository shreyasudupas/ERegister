using ERegister.CustomerRegistrationManagement.Core.Features.Employee.Commands.AddEmployee;
using ERegister.CustomerRegistrationManagement.Core.Response;

namespace ERegister.CustomerRegistrationManagement.Core.Features.Employee.Commands.UpdateEmployee
{
    public class UpdateEmployeeResponse : BaseResponse
    {
        public UpdateEmployeeResponse() : base()
        {
        }

        public EmployeeDtos Employee { get; set; }
    }
}
