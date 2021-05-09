using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.UpdateCommand {
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool> {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler (IProductRepository productRepository, IMapper mapper) {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle (UpdateProductCommand request, CancellationToken cancellationToken) {
            var productToUpdate = await _productRepository.GetByIdAsync (request.Id);
            if (productToUpdate == null) {
                return false;
            }
            _mapper.Map (request, productToUpdate, typeof (UpdateProductCommand), typeof (Product));
            await _productRepository.UpdateAsync (productToUpdate);
            return true;
        }
    }
}