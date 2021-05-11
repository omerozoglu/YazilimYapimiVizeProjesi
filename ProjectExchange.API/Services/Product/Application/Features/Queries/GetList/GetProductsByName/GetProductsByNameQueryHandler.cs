using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetList.GetProductsByName {
    public class GetProductsByNameQueryHandler : IRequestHandler<GetProductsByNameQuery, List<ProductVm>> {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsByNameQueryHandler (IProductRepository productRepository, IMapper mapper) {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductVm>> Handle (GetProductsByNameQuery request, CancellationToken cancellationToken) {
            var productList = await _productRepository.GetAsync (
                p => (p.Name == request.model.Name) && (p.UnitPrice != 0));

            return _mapper.Map<List<ProductVm>> (productList);
        }
    }
}