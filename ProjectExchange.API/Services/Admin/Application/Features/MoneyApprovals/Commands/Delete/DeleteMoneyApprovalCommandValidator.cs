using FluentValidation;

namespace Application.Features.MoneyApprovals.Commands.Delete {
    public class DeleteMoneyApprovalCommandValidator : AbstractValidator<DeleteMoneyApprovalCommand> {
        public DeleteMoneyApprovalCommandValidator () {

            RuleFor (p => p.Id)
                .NotEmpty ()
                .WithMessage ("{Id} is required.")
                .NotNull ()
                .Length (24)
                .WithMessage ("{Id} must be 24 characters.");
        }
    }
}