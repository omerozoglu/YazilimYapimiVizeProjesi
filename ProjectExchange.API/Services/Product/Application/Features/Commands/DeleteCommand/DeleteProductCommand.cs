using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.DeleteCommand {
    public class DeleteProductCommand : IRequest<EntityResponse<Product>> {
        public string Id { get; set; }
    }
}