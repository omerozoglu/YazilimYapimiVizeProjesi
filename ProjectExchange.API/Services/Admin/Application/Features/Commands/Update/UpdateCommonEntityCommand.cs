using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Update {
    public class UpdateCommonEntityCommand<T> : CommonEntity<T>, IRequest<EntityResponse<CommonEntity<T>>> where T : ApprovalEntityBase { }
}