using Application.Models;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.CreateCommand {
    public class CreateProductCommand : ProductVm, IRequest<Product> {
        public string Id { get; }
    }
}