using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetList.GetProductsByName {
    public class GetProductsByNameQueryHandler : IRequestHandler<GetProductsByNameQuery, EntityResponse<Product>> {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsByNameQueryHandler (IProductRepository productRepository, IMapper mapper) {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<Product>> Handle (GetProductsByNameQuery request, CancellationToken cancellationToken) {
            var response = new EntityResponse<Product> () { ReponseName = nameof (GetProductsByNameQuery), Content = new List<Product> () { } };
            var productList = await _productRepository.GetListAsync (
                p => (p.Name == request.model.Name) && (p.UnitPrice != 0));
            _mapper.Map<List<Product>> (productList);
            if (productList == null) {
                response.Status = ResponseType.Error;
                response.Message = "No products were found.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = "Products get successfully.";
                response.Content.AddRange (productList);
            }
            return response;
        }
    }
}