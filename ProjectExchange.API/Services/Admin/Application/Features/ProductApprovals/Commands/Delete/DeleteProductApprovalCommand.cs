using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductApprovals.Commands.Delete {
    public class DeleteProductApprovalCommand : IRequest<EntityResponse<ProductApproval>> {
        public DeleteProductApprovalCommand (string id) {
            Id = id;
        }

        public string Id { get; set; }
    }
}