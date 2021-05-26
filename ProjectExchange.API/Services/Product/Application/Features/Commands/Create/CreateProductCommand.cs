using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Create {
    public class CreateProductCommand : Product, IRequest<EntityResponse<Product>> { }
}