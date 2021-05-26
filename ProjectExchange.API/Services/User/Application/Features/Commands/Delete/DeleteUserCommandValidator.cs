using FluentValidation;

namespace Application.Features.Commands.Delete {
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand> {
        public DeleteUserCommandValidator () {

            RuleFor (p => p.Id)
                .NotEmpty ()
                .WithMessage ("{Id} is required.")
                .NotNull ()
                .Length (24)
                .WithMessage ("{Id} must be 24 characters.");
        }
    }
}