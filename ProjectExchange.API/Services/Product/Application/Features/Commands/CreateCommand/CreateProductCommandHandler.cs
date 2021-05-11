using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.CreateCommand {
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product> {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler (IProductRepository productRepository, IMapper mapper) {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Product> Handle (CreateProductCommand request, CancellationToken cancellationToken) {
            var productEntity = _mapper.Map<Product> (request);
            var newProduct = await _productRepository.AddAsync (productEntity);
            if (newProduct == null) {
                return null;
            }
            return newProduct;
        }
    }
}