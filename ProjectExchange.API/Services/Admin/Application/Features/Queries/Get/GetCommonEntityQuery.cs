using Application.Models;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.Get {
    public class GetCommonEntityQuery : IRequest<EntityResponse<CommonEntity>> {
        public GetCommonEntityQuery (string id) {
            Id = id;
        }

        public string Id { get; set; }
    }
}