using System.Collections.Generic;
using Application.Models;
using MediatR;

namespace Application.Features.Queries.GetList {
    public class GetUsersListQuery : IRequest<List<UserVm>> {
        //* tamamını çağırdığım için herhangi bir özelllik eklemiyorum
    }
}