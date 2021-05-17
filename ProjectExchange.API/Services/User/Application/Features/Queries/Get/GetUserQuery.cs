using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.Get {
    public class GetUserQuery : IRequest<EntityResponse<User>> {
        public string Id { get; set; }
        public GetUserQuery (string Id) {
            this.Id = Id;
        }
    }
}