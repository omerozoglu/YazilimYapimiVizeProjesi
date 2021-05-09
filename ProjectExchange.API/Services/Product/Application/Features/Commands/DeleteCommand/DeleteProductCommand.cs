using MediatR;

namespace Application.Features.Commands.DeleteCommand {
    public class DeleteProductCommand : IRequest<bool> {
        public string Id { get; set; }
    }
}