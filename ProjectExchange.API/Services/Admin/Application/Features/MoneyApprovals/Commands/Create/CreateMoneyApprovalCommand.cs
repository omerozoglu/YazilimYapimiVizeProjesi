using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.MoneyApprovals.Commands.Create {
    public class CreateMoneyApprovalCommand : MoneyApproval, IRequest<EntityResponse<MoneyApproval>> {

    }
}