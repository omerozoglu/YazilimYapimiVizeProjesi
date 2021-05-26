using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Delete {
    public class DeleteUserCommand : IRequest<EntityResponse<User>> {
        public string Id { get; set; }
    }
}