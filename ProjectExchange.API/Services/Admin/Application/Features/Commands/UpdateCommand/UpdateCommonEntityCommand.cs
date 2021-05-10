using Application.Models;
using MediatR;

namespace Application.Features.Commands.UpdateCommand {
    public class UpdateCommonEntityCommand : CommonEntityVm, IRequest<bool> {

    }
}