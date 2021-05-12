using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.Get {
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, EntityResponse<Product>> {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductQueryHandler (IProductRepository productRepository, IMapper mapper) {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<Product>> Handle (GetProductQuery request, CancellationToken cancellationToken) {
            var response = new EntityResponse<Product> () { ReponseName = nameof (GetProductQuery), Content = new List<Product> () { } };
            var product = await _productRepository.GetByIdAsync (request.Id);
            product = _mapper.Map<Product> (product);
            if (product == null) {
                response.Status = ResponseType.Error;
                response.Message = "Product not found.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = "Product get successfully.";
                response.Content.Add (product);
            }
            return response;
        }
    }
}