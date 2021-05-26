using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Delete {
    public class DeleteCommonEntityCommand : IRequest<EntityResponse<CommonEntity>> {
        public string Id { get; set; }
    }
}