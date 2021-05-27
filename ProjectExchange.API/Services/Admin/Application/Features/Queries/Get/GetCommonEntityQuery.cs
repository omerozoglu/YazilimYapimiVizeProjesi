using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.Get {
    public class GetCommonEntityQuery<T> : IRequest<EntityResponse<CommonEntity<T>>> where T : ApprovalEntityBase {
        public GetCommonEntityQuery (string id) {
            Id = id;
        }

        public string Id { get; set; }
    }
}