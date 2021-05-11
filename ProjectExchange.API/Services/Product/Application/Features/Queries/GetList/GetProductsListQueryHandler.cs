using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetList {
    public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, List<Product>> {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsListQueryHandler (IProductRepository productRepository, IMapper mapper) {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<Product>> Handle (GetProductsListQuery request, CancellationToken cancellationToken) {
            var productList = await _productRepository.GetAllAsync ();
            return _mapper.Map<List<Product>> (productList);
        }
    }
}