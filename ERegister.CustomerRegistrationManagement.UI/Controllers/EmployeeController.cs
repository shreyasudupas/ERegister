using ERegister.CustomerRegistrationManagement.Core.Features.Employee.Commands.AddEmployee;
using ERegister.CustomerRegistrationManagement.Core.Features.Employee.Commands.UpdateEmployee;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ERegister.CustomerRegistrationManagement.UI.Controllers
{
    public class EmployeeController : ApiControllerBase
    {
        [HttpPost]
        public async Task<AddEmployeeResponse> AddEmployee(AddEmployeeCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut]
        [SwaggerResponse(StatusCodes.Status200OK
            ,Type = typeof(UpdateEmployeeResponse)
            ,Description = "Returns Updated Employee")]
        [SwaggerResponse(StatusCodes.Status404NotFound
            , Type = typeof(ExceptionResponseModel)
            , Description = "Returns Not Found Employee")]
        public async Task<UpdateEmployeeResponse> UpdateEmployee(UpdateEmployeeCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
