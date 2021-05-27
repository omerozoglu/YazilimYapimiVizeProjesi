using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Create {
    public class CreateCommonEntityCommand<T> : CommonEntity<T>, IRequest<EntityResponse<CommonEntity<T>>> where T : ApprovalEntityBase {

    }
}