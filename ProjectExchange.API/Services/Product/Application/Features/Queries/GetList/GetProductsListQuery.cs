using System.Collections.Generic;
using Application.Models;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetList {
    public class GetProductsListQuery : IRequest<EntityResponse<Product>> {
        //* tamamını çağırdığım için herhangi bir özelllik eklemiyorum
    }
}