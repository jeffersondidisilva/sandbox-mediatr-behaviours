using MediatR;

namespace Sandbox.MediatR.Behaviours.API.Persons
{
    public class Person : IRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }
    }
}
