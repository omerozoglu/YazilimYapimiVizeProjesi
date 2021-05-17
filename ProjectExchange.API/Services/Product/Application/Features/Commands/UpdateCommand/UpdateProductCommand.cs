using Application.Models;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.UpdateCommand {
    public class UpdateProductCommand : ProductVm, IRequest<EntityResponse<Product>> {
        public string Id { get; set; }
    }
}