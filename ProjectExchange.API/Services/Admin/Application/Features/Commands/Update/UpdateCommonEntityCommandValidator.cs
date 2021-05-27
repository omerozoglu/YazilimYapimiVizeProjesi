using Domain.Common;
using FluentValidation;

namespace Application.Features.Commands.Update {
    public class UpdateCommonEntityCommandValidator<T> : AbstractValidator<UpdateCommonEntityCommand<T>> where T : ApprovalEntityBase {
        public UpdateCommonEntityCommandValidator () {
            RuleFor (p => p.Id)
                .NotEmpty ()
                .WithMessage ("{Id} is required.")
                .NotNull ()
                .Length (24)
                .WithMessage ("{Id} must be 24 characters.");
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