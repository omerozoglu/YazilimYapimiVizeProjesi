using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Create {
    public class CreateUserCommand : User, IRequest<EntityResponse<User>> {

    }
}