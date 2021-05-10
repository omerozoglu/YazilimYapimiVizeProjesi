using Application.Models;
using MediatR;

namespace Application.Features.Queries.GetQuery {
    public class GetCommonEntityQuery : IRequest<CommonEntityVm> {
        public GetCommonEntityQuery (string id) {
            Id = id;
        }

        public string Id { get; set; }
    }
}