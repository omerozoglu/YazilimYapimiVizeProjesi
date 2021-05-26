using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Update {
    public class UpdateCommonEntityCommand : CommonEntity, IRequest<EntityResponse<CommonEntity>> { }
}