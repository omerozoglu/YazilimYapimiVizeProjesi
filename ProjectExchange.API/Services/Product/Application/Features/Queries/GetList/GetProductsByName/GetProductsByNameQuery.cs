using Application.Models;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetList.GetProductsByName {
    public class GetProductsByNameQuery : IRequest<EntityResponse<Product>> {
        public GetProductsByNameQuery (ProductVm model) {
            this.model = model;
        }

        public ProductVm model { get; set; }

    }
}