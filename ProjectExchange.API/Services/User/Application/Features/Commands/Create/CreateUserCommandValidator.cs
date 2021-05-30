using FluentValidation;

namespace Application.Features.Commands.Create{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand> {
        public CreateUserCommandValidator () {
            RuleFor (p => p.Name)
                .NotEmpty ()
                .WithMessage ("{Name} is required.")
                .NotNull ()
                .MaximumLength (30)
                .WithMessage ("{Name} must not exceed 30 characters.");
            RuleFor (p => p.Username)
                .NotEmpty ()
                .WithMessage ("{Username} is required.")
                .NotNull ();
            RuleFor (p => p.Password)
                .NotEmpty ()
                .WithMessage ("{Password} is required.")
                .NotNull ();
            RuleFor (p => p.Email)
                .NotEmpty ()
                .WithMessage ("{Email} is required.")
                .EmailAddress ()
                .WithMessage ("A valid {Email} is required");
        }
    }
}