using Application.Models;
using MediatR;

namespace Application.Features.Commands.UpdateCommand.UpdateOneProperty {
    public class UpdateOnePropertyCommand : UpdateOnePropModel, IRequest<bool> {

    }
}