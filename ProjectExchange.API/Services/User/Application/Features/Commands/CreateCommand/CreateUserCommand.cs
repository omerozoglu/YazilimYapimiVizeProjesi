using Application.Models;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.CreateCommand {
    public class CreateUserCommand : UserVm, IRequest<EntityResponse<User>> { }
}