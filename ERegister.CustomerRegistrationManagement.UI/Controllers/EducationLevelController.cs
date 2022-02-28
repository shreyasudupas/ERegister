using ERegister.CustomerRegistrationManagement.Core.Features.GetEductationLevel.Query;
using Microsoft.AspNetCore.Mvc;

namespace ERegister.CustomerRegistrationManagement.UI.Controllers
{
    public class EducationLevelController : ApiControllerBase
    {
        [HttpGet]
        public async Task<List<GetEducationLevelDtos>> Get()
        {
            var result = await Mediator.Send(new GetEducationLevelQuery());
            return result;
        }
    }
}
