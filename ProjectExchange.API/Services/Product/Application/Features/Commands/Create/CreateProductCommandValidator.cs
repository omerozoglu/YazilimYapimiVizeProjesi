using FluentValidation;

namespace Application.Features.Commands.Create {
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand> {
        public CreateProductCommandValidator () {
            RuleFor (p => p.Name)
                .NotEmpty ()
                .WithMessage ("{Name} is required.")
                .NotNull ()
                .MaximumLength (30)
                .WithMessage ("{Name} must not exceed 30 characters.");
        }
    }
}