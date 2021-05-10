using MediatR;

namespace Application.Features.Commands.DeleteCommand {
    public class DeleteCommonEntityCommand : IRequest<bool> {
        public string Id { get; set; }
    }
}