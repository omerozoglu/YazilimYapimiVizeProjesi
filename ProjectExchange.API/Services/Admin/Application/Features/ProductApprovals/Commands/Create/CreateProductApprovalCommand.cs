using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductApprovals.Commands.Create {
    public class CreateProductApprovalCommand : ProductApproval, IRequest<EntityResponse<ProductApproval>> {

    }
}