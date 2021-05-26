using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetList {
    public class GetListCommonEntityQuery : IRequest<EntityResponse<CommonEntity>> {

    }
}