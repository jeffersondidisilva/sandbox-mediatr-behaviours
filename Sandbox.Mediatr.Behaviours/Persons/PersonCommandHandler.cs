using System.Diagnostics;
using MediatR;
using Sandbox.MediatR.Behaviours.API.Sms;

namespace Sandbox.MediatR.Behaviours.API.Persons
{
    public class PersonCommandHandler : RequestHandler<PersonCommand>
    {
        private readonly IMediator _mediator;

        public PersonCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected override void Handle(PersonCommand request)
        {
            //Implement mapper and repository logic
            Debug.WriteLine("Saving Person...");
            _mediator.Send(new SmsCommand
            {
                Phone = request.Phone
            });
        }
    }
}
