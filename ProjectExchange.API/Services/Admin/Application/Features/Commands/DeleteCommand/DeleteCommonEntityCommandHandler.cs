using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace Application.Features.Commands.DeleteCommand {
    public class DeleteCommonEntityCommandHandler : IRequestHandler<DeleteCommonEntityCommand, bool> {
        private readonly ICommonEntityRepository _commonEntityRepository;
        private readonly IMapper _mapper;

        public DeleteCommonEntityCommandHandler (ICommonEntityRepository commonEntityRepository, IMapper mapper) {
            _commonEntityRepository = commonEntityRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle (DeleteCommonEntityCommand request, CancellationToken cancellationToken) {
            var commonEntityToDelete = await _commonEntityRepository.GetByIdAsync (request.Id);
            await _commonEntityRepository.DeleteAsync (commonEntityToDelete);
            if (commonEntityToDelete == null) {
                return false;
            }
            return true;
        }
    }
}