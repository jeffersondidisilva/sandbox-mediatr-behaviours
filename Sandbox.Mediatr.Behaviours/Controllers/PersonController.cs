using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sandbox.MediatR.Behaviours.API.Controllers.Common;
using Sandbox.MediatR.Behaviours.API.Persons;

namespace Sandbox.MediatR.Behaviours.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : BaseController
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonCommand command)
        {
            _mediator.Send(command);
            return OkResult();
        }
    }
}
