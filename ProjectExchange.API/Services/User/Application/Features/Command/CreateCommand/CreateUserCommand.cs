using Application.Models;
using MediatR;

namespace Application.Features.Command.CreateCommand {
    public class CreateUserCommand : UserVm, IRequest<bool> {

    }
}