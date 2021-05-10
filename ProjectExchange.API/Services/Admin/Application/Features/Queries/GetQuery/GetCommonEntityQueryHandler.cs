using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.Queries.GetQuery {
    public class GetCommonEntityQueryHandler : IRequestHandler<GetCommonEntityQuery, CommonEntityVm> {

        private readonly ICommonEntityRepository _commonEntityRepository;
        private readonly IMapper _mapper;

        public GetCommonEntityQueryHandler (ICommonEntityRepository commonEntityRepository, IMapper mapper) {
            _commonEntityRepository = commonEntityRepository;
            _mapper = mapper;
        }

        public async Task<CommonEntityVm> Handle (GetCommonEntityQuery request, CancellationToken cancellationToken) {
            var commonEntity = await _commonEntityRepository.GetByIdAsync (request.Id);
            return _mapper.Map<CommonEntityVm> (commonEntity);
        }
    }
}