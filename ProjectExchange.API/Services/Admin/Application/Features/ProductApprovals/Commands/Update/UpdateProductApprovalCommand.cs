using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductApprovals.Commands.Update {
    public class UpdateProductApprovalCommand : ProductApproval, IRequest<EntityResponse<ProductApproval>> {

    }
}