using System.Collections.Generic;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetList {
    public class GetUsersListQuery : IRequest<List<User>> {
        //* tamamını çağırdığım için herhangi bir özelllik eklemiyorum
    }
}