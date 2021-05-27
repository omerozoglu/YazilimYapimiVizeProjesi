using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Delete {
    public class DeleteProductCommand : IRequest<EntityResponse<Product>> {
        public DeleteProductCommand (string id) {
            Id = id;
        }

        public string Id { get; set; }
    }
}