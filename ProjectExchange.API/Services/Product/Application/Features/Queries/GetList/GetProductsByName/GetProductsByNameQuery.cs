using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetList.GetProductsByName {
    public class GetProductsByNameQuery : IRequest<EntityResponse<Product>> {
        public GetProductsByNameQuery (string productName) {
            this.productName = productName;
        }

        public string productName { get; set; }

    }
}