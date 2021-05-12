using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.DeleteCommand {
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, EntityResponse<Product>> {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler (IProductRepository productRepository, IMapper mapper) {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<Product>> Handle (DeleteProductCommand request, CancellationToken cancellationToken) {
            var response = new EntityResponse<Product> () { ReponseName = nameof (DeleteProductCommand), Content = new List<Product> () { } };
            var productToDelete = await _productRepository.GetByIdAsync (request.Id);
            if (productToDelete == null) {
                response.Status = ResponseType.Error;
                response.Message = "Product not found.";
                response.Content = null;
            } else {
                await _productRepository.DeleteAsync (productToDelete);
                response.Status = ResponseType.Success;
                response.Message = "Product deleted successfully.";
                response.Content.Add (productToDelete);
            }
            return response;
        }
    }
}