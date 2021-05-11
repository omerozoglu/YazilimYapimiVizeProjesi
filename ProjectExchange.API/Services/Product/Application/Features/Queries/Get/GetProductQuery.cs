using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.Get {
    public class GetProductQuery : IRequest<Product> {
        public string Id { get; set; }
        public GetProductQuery (string Id) {
            this.Id = Id;
        }
    }
}