using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.Queries.GetList {
    public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, List<ProductVm>> {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsListQueryHandler (IProductRepository productRepository, IMapper mapper) {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductVm>> Handle (GetProductsListQuery request, CancellationToken cancellationToken) {
            var productList = await _productRepository.GetAllAsync ();
            return _mapper.Map<List<ProductVm>> (productList);
        }
    }
}