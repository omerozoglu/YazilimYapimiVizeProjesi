using Domain.Common;
using FluentValidation;

namespace Application.Features.Commands.Delete {
    public class DeleteCommonEntityCommandValidator<T> : AbstractValidator<DeleteCommonEntityCommand<T>> where T : ApprovalEntityBase {
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