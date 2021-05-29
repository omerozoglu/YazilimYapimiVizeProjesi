using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductApprovals.Queries.GetList {
    public class GetListProductApprovalQuery : IRequest<EntityResponse<ProductApproval>> {

    }
}