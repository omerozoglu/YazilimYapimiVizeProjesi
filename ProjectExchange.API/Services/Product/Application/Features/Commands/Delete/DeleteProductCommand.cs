using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Delete {
    public class DeleteProductCommand : IRequest<EntityResponse<Product>> {
        public string Id { get; set; }
    }
}