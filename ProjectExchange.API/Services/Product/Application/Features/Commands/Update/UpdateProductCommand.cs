using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Update {
    public class UpdateProductCommand : Product, IRequest<EntityResponse<Product>> {

    }
}