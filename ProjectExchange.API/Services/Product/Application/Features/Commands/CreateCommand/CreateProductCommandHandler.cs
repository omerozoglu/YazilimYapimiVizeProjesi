using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.CreateCommand {
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, EntityResponse<Product>> {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler (IProductRepository productRepository, IMapper mapper) {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<Product>> Handle (CreateProductCommand request, CancellationToken cancellationToken) {
            var response = new EntityResponse<Product> () { ReponseName = nameof (CreateProductCommand), Content = new List<Product> () { } };
            var productEntity = _mapper.Map<Product> (request);
            var newProduct = await _productRepository.AddAsync (productEntity);
            if (newProduct == null) {
                response.Status = ResponseType.Error;
                response.Message = "Product could not be created.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = "Product created successfully.";
                response.Content.Add (newProduct);
            }
            return response;
        }
    }
}