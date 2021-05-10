using System.Collections.Generic;
using Application.Models;
using MediatR;

namespace Application.Features.Queries.GetListQuery {
    public class GetListCommonEntityQuery : IRequest<List<CommonEntityVm>> {

    }
}