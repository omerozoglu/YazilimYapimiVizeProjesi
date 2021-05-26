using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Create {
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, EntityResponse<Product>> {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler (IProductRepository productRepository, IMapper mapper) {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<Product>> Handle (CreateProductCommand request, CancellationToken cancellationToken) {
            var response = new EntityResponse<Product> () { ReponseName = nameof (CreateProductCommand), Content = new List<Product> () { } };
            var entity = _mapper.Map<Product> (request);
            var newentity = await _productRepository.AddAsync (entity);
            if (newentity == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"{nameof(Product)} could not be created.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Product)} created successfully.";
                response.Content.Add (newentity);
            }
            return response;
        }
    }
}