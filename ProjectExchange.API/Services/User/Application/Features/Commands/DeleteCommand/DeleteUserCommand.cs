using MediatR;

namespace Application.Features.Commands.DeleteCommand {
    public class DeleteUserCommand : IRequest<bool> {
        public string Id { get; set; }
    }
}