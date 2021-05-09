using MediatR;

namespace Application.Features.Command.DeleteCommand {
    public class DeleteUserCommand : IRequest<bool> {
        public string Id { get; set; }
    }
}