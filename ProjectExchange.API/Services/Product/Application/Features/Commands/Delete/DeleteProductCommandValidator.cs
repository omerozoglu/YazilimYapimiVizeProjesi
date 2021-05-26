using FluentValidation;

namespace Application.Features.Commands.Delete {
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand> {
        public DeleteProductCommandValidator () {

            RuleFor (p => p.Id)
                .NotEmpty ()
                .WithMessage ("{Id} is required.")
                .NotNull ()
                .Length (24)
                .WithMessage ("{Id} must be 24 characters.");
        }
    }
}