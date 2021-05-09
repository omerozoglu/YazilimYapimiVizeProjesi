using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Commands.DeleteCommand {
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool> {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler (IProductRepository productRepository, IMapper mapper) {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle (DeleteProductCommand request, CancellationToken cancellationToken) {
            var productToDelete = await _productRepository.GetByIdAsync (request.Id);
            await _productRepository.DeleteAsync (productToDelete);
            if (productToDelete == null) {
                return false;
            }
            return true;
        }
    }
}