using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetList {
    public class GetReportsListQuery : IRequest<EntityResponse<Report>> {
        //* tamamını çağırdığım için herhangi bir özelllik eklemiyorum
    }
}