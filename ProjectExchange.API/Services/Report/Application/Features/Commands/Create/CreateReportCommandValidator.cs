using FluentValidation;

namespace Application.Features.Commands.Create {
    public class CreateUserCommandValidator : AbstractValidator<CreateReportCommand> {
        public CreateUserCommandValidator () {
            RuleFor (p => p.CreatedBy)
                .NotEmpty ()
                .WithMessage ("{CreatedBy} is required.")
                .NotNull ()
                .Length (24)
                .WithMessage ("{CreatedBy} must be 24 characters.");
        }
    }
}