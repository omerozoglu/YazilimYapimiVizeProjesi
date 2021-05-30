using FluentValidation;

namespace Application.Features.MoneyApprovals.Commands.Update {
    public class UpdateMoneyApprovalCommandValidator : AbstractValidator<UpdateMoneyApprovalCommand> {
        public UpdateMoneyApprovalCommandValidator () {
            RuleFor (p => p.Id)
                .NotEmpty ()
                .WithMessage ("{Id} is required.")
                .NotNull ()
                .Length (24)
                .WithMessage ("{Id} must be 24 characters.");
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