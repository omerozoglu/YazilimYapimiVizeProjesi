using System.Collections.Generic;
using Application.Models;
using MediatR;

namespace Application.Features.Queries.GetList {
    public class GetProductsListQuery : IRequest<List<ProductVm>> {
        //* tamamını çağırdığım için herhangi bir özelllik eklemiyorum
    }
}