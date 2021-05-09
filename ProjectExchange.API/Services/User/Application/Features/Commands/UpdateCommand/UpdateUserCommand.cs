using Application.Models;
using MediatR;

namespace Application.Features.Commands.UpdateCommand {
    public class UpdateUserCommand : UserVm, IRequest<bool> {
        public string Id { get; set; }
    }
}