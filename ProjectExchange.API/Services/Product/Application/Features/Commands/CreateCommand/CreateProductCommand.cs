using Application.Models;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.CreateCommand {
    public class CreateProductCommand : ProductVm, IRequest<EntityResponse<Product>> {
    }
}