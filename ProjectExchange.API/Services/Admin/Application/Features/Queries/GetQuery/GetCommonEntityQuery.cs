using Application.Models;
using MediatR;

namespace Application.Features.Queries.GetQuery {
    public class GetCommonEntityQuery : IRequest<CommonEntityVm> {
        public string Id { get; set; }
    }
}