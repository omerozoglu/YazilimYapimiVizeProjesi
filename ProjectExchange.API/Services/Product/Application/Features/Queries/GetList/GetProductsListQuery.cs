using System.Collections.Generic;
using Application.Models;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetList {
    public class GetProductsListQuery : IRequest<List<Product>> {
        //* tamamını çağırdığım için herhangi bir özelllik eklemiyorum
    }
}