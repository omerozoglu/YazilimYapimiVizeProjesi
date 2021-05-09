using Application.Models;
using MediatR;

namespace Application.Features.Commands.CreateCommand {
    public class CreateUserCommand : UserVm, IRequest<bool> {

    }
}