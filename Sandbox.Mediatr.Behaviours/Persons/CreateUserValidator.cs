using FluentValidation;

namespace Sandbox.MediatR.Behaviours.API.Persons
{
    public class CreateUserValidator : AbstractValidator<PersonCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty().WithMessage("Name is required");

            RuleFor(a => a.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email");

            RuleFor(a => a.Cpf)
                .NotEmpty().WithMessage("Cpf is required");

            RuleFor(a => a.Phone)
                .NotEmpty().WithMessage("Phone is required");
        }
    }
}
