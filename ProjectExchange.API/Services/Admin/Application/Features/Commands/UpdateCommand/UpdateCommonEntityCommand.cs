using Application.Models;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.UpdateCommand {
    public class UpdateCommonEntityCommand : CommonEntityVm, IRequest<EntityResponse<CommonEntity>> {
        public string Id { get; set; }
    }
}