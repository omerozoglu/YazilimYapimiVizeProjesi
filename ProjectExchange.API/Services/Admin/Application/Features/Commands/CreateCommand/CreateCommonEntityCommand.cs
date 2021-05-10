using Application.Models;
using MediatR;

namespace Application.Features.Commands.CreateCommand {
    public class CreateCommonEntityCommand : CommonEntityVm, IRequest<bool> {
        private string Id { get; set; }
    }
}