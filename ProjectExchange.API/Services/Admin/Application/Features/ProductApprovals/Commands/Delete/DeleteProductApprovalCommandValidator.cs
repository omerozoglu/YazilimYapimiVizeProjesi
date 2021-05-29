using FluentValidation;

namespace Application.Features.ProductApprovals.Commands.Delete {
    public class DeleteProductApprovalCommandValidator : AbstractValidator<DeleteProductApprovalCommand> {
        public DeleteProductApprovalCommandValidator () {

            RuleFor (p => p.Id)
                .NotEmpty ()
                .WithMessage ("{Id} is required.")
                .NotNull ()
                .Length (24)
                .WithMessage ("{Id} must be 24 characters.");
        }
    }
}