using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetList {
    public class GetUsersListQuery : IRequest<EntityResponse<User>> {
        //* tamamını çağırdığım için herhangi bir özelllik eklemiyorum
    }
}