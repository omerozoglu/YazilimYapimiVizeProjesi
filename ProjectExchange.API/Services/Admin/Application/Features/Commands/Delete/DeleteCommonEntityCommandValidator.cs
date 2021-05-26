using FluentValidation;

namespace Application.Features.Commands.Delete {
    public class DeleteCommonEntityCommandValidator : AbstractValidator<DeleteCommonEntityCommand> {
        public DeleteCommonEntityCommandValidator () {

            RuleFor (p => p.Id)
                .NotEmpty ()
                .WithMessage ("{Id} is required.")
                .NotNull ()
                .Length (24)
                .WithMessage ("{Id} must be 24 characters.");
        }
    }
}