using Domain.Common;
using FluentValidation;

namespace Application.Features.Commands.Create {
    public class CreateCommonEntityCommandValidator<T> : AbstractValidator<CreateCommonEntityCommand<T>> where T : ApprovalEntityBase {
        public CreateCommonEntityCommandValidator () {
            RuleFor (p => p.ApprovalEntity.UserId)
                .NotEmpty ()
                .WithMessage ("{ApprovalEntity.UserId} is required.")
                .NotNull ()
                .Length (24)
                .WithMessage ("{UserId} must be 24 characters.");
            RuleFor (p => p.ApprovalEntity.Type)
                .NotEmpty ()
                .WithMessage ("{ApprovalEntity.Type} is required.")
                .NotNull ();
            RuleFor (p => p.ApprovalEntity.Status)
                .NotEmpty ()
                .WithMessage ("{ApprovalEntity.Status} is required.")
                .NotNull ();
        }
    }
}