using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.DeleteCommand {
    public class DeleteCommonEntityCommand : IRequest<EntityResponse<CommonEntity>> {
        public string Id { get; set; }
    }
}