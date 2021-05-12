using Application.Models;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.UpdateCommand {
    public class UpdateUserCommand : UserVm, IRequest<EntityResponse<User>> { public string Id { get; set; } }
}