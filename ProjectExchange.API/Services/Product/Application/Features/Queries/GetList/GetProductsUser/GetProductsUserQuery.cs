using System.Collections.Generic;
using Application.Models;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetList.GetProductsUser {
    public class GetProductsUserQuery : IRequest<EntityResponse<Product>> {
        public GetProductsUserQuery (List<string> productIds) {
            this.productIds = productIds;
        }

        public List<string> productIds { get; set; }

    }
}