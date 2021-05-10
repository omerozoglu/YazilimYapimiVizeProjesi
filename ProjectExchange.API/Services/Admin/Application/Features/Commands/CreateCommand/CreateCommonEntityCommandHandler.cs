using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.CreateCommand {
    public class CreateCommonEntityCommandHandler : IRequestHandler<CreateCommonEntityCommand, bool> {

        private readonly ICommonEntityRepository _commonEntityRepository;
        private readonly IMapper _mapper;

        public CreateCommonEntityCommandHandler (ICommonEntityRepository commonEntityRepository, IMapper mapper) {
            _commonEntityRepository = commonEntityRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle (CreateCommonEntityCommand request, CancellationToken cancellationToken) {
            var commonEntity = _mapper.Map<CommonEntity> (request);
            var newCommonEntity = await _commonEntityRepository.AddAsync (commonEntity);
            if (newCommonEntity == null)
                return false;

            return true;
        }
    }
}