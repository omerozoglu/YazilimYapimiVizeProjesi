using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Create {
    public class CreateReportCommand : Report, IRequest<EntityResponse<Report>> {

    }
}