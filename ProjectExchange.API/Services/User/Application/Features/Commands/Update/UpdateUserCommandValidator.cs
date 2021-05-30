using FluentValidation;

namespace Application.Features.Commands.Update {
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand> {
        public UpdateUserCommandValidator () {

            RuleFor (p => p.Id)
                .NotEmpty ()
                .WithMessage ("{Id} is required.")
                .NotNull ()
                .Length (24)
                .WithMessage ("{Id} must be 24 characters.");
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