using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.MoneyApprovals.Queries.Get {
    public class GetMoneyApprovalQuery : IRequest<EntityResponse<MoneyApproval>> {
        public GetMoneyApprovalQuery (string id) {
            Id = id;
        }

        public string Id { get; set; }
    }
}