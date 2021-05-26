using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Create {
    public class CreateCommonEntityCommand : CommonEntity, IRequest<EntityResponse<CommonEntity>> {
    }
}