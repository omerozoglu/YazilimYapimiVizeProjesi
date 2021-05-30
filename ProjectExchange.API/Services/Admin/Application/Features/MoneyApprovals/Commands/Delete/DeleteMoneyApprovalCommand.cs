using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.MoneyApprovals.Commands.Delete {
    public class DeleteMoneyApprovalCommand : IRequest<EntityResponse<MoneyApproval>> {
        public DeleteMoneyApprovalCommand (string id) {
            Id = id;
        }

        public string Id { get; set; }
    }
}