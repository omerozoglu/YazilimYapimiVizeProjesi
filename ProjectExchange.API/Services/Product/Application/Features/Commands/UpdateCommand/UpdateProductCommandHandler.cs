using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.UpdateCommand {
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, EntityResponse<Product>> {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler (IProductRepository productRepository, IMapper mapper) {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<Product>> Handle (UpdateProductCommand request, CancellationToken cancellationToken) {
            var productToUpdate = await _productRepository.GetByIdAsync (request.Id);
            var response = new EntityResponse<Product> () { ReponseName = nameof (UpdateProductCommand), Content = new List<Product> () { } };
            if (productToUpdate == null) {
                response.Status = ResponseType.Error;
                response.Message = "Product not found.";
                response.Content = null;
            } else {
                _mapper.Map (request, productToUpdate, typeof (UpdateProductCommand), typeof (Product));
                await _productRepository.UpdateAsync (productToUpdate);
                response.Status = ResponseType.Success;
                response.Message = "Product updated successfully.";
                response.Content.Add (productToUpdate);
            }
            return response;
        }
    }
}