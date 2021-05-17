using Application.Models;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.CreateCommand {
    public class CreateCommonEntityCommand : CommonEntityVm, IRequest<EntityResponse<CommonEntity>> {
        private string Id { get; set; }
    }
}