using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Delete {
    public class DeleteCommonEntityCommand<T> : IRequest<EntityResponse<CommonEntity<T>>> where T : ApprovalEntityBase {
        public string Id { get; set; }
    }
}