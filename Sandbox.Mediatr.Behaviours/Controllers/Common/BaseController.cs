using Microsoft.AspNetCore.Mvc;

namespace Sandbox.MediatR.Behaviours.API.Controllers.Common
{
    public class BaseController : ControllerBase
    {
        public IActionResult OkResult(object result = null)
        {
            if (Validations.HasErrors)
                return Ok(Validations.Errors);

            if(result == null)
                return Ok("OK");

            return Ok(result);
        }
    }
}
