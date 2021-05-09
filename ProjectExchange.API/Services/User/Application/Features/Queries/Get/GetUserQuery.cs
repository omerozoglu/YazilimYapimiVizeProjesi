using Application.Models;
using MediatR;

namespace Application.Features.Queries.Get {
    public class GetUserQuery : IRequest<UserVm> {
        public string Id { get; set; }
        public GetUserQuery (string Id) {
            this.Id = Id;
        }
    }
}