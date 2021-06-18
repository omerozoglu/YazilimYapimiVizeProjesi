using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetList.GetProductsWithStatusByName {
    public class GetProductsWithStatusByNameQuery : IRequest<EntityResponse<Product>> {
        public GetProductsWithStatusByNameQuery (string productName) {
            this.productName = productName;
        }

        public string productName { get; set; }

    }
}