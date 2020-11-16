using MediatR;
using Sandbox.MediatR.Behaviours.API.Attributes;

namespace Sandbox.MediatR.Behaviours.API.Persons
{
    public class PersonCommand : IRequest
    {
        public string Name { get; set; }

        public string Email { get; set; }

        [OnlyDigits]
        public string Cpf { get; set; }

        [OnlyDigits]
        public string Phone { get; set; }
    }
}
