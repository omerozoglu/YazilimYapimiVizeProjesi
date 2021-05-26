using FluentValidation;

namespace Application.Features.Commands.Create {
    public class CreateCommonEntityCommandValidator : AbstractValidator<CreateCommonEntityCommand> {
        public CreateCommonEntityCommandValidator () {
            RuleFor (p => p.UserId)
                .NotEmpty ()
                .WithMessage ("{UserId} is required.")
                .NotNull ()
                .Length (24)
                .WithMessage ("{UserId} must be 24 characters.");
            RuleFor (p => p.Type)
                .NotEmpty ()
                .WithMessage ("{Type} is required.")
                .NotNull ();
            RuleFor (p => p.Status)
                .NotEmpty ()
                .WithMessage ("{Status} is required.")
                .NotNull ();
        }
    }
}