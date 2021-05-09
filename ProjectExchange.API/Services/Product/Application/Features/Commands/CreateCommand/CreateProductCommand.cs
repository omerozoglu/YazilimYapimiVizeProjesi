using Application.Models;
using MediatR;

namespace Application.Features.Commands.CreateCommand {
    public class CreateProductCommand : ProductVm, IRequest<bool> {

    }
}