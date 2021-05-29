using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.MoneyApprovals.Commands.Update {
    public class UpdateMoneyApprovalCommand : MoneyApproval, IRequest<EntityResponse<MoneyApproval>> {

    }
}