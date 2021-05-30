using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Delete {
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, EntityResponse<Product>> {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler (IProductRepository productRepository, IMapper mapper) {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<Product>> Handle (DeleteProductCommand request, CancellationToken cancellationToken) {
            var response = new EntityResponse<Product> () { ReponseName = nameof (DeleteProductCommand), Content = new List<Product> () { } };
            var entity = await _productRepository.GetOneAsync (p => p.Id == request.Id);
            if (entity == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"{nameof(Product)} not found.";
                response.Content = null;
            } else {
                await _productRepository.DeleteAsync (entity);
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Product)} deleted successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}