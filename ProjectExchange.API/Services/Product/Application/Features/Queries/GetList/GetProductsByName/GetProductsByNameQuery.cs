using System.Collections.Generic;
using Application.Models;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetList.GetProductsByName {
    public class GetProductsByNameQuery : IRequest<List<ProductVm>> {
        public GetProductsByNameQuery (ProductVm model) {
            this.model = model;
        }

        public ProductVm model { get; set; }

    }
}