using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductApprovals.Queries.Get {
    public class GetProductApprovalQuery : IRequest<EntityResponse<ProductApproval>> {
        public GetProductApprovalQuery (string id) {
            Id = id;
        }

        public string Id { get; set; }
    }
}