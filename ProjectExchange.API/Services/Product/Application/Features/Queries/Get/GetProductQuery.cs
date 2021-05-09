using Application.Models;
using MediatR;

namespace Application.Features.Queries.Get {
    public class GetProductQuery : IRequest<ProductVm> {
        public string Id { get; set; }
        public GetProductQuery (string Id) {
            this.Id = Id;
        }
    }
}