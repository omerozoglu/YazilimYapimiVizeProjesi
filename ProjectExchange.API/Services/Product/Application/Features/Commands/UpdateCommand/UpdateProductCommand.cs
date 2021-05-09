using Application.Models;
using MediatR;

namespace Application.Features.Commands.UpdateCommand {
    public class UpdateProductCommand : ProductVm, IRequest<bool> {
        public string Id { get; set; }

    }
}