using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetList.GetProductsByName {
    public class GetProductsByNameQuery : IRequest<EntityResponse<Product>> {
        public GetProductsByNameQuery (Product model) {
            this.model = model;
        }

        public Product model { get; set; }

    }
}