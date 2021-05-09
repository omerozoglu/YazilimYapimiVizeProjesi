using Application.Models;
using MediatR;

namespace Application.Features.Command.UpdateCommand {
    public class UpdateUserCommand : UserVm, IRequest<bool> { }
}