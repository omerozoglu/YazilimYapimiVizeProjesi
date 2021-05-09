using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.Queries.Get {
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductVm> {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductQueryHandler (IProductRepository productRepository, IMapper mapper) {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductVm> Handle (GetProductQuery request, CancellationToken cancellationToken) {
            var product = await _productRepository.GetByIdAsync (request.Id);
            return _mapper.Map<ProductVm> (product);
        }
    }
}