using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.MoneyApprovals.Queries.GetList {
    public class GetListMoneyApprovalQuery : IRequest<EntityResponse<MoneyApproval>> {

    }
}