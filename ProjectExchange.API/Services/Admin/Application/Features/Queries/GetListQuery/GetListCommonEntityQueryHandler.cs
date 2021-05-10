using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.Queries.GetListQuery {
    public class GetListCommonEntityQueryHandler : IRequestHandler<GetListCommonEntityQuery, List<CommonEntityVm>> {
        private readonly ICommonEntityRepository _commonEntityRepository;
        private readonly IMapper _mapper;

        public GetListCommonEntityQueryHandler (ICommonEntityRepository commonEntityRepository, IMapper mapper) {
            _commonEntityRepository = commonEntityRepository;
            _mapper = mapper;
        }
        public async Task<List<CommonEntityVm>> Handle (GetListCommonEntityQuery request, CancellationToken cancellationToken) {
            var commonEntities = await _commonEntityRepository.GetAllAsync ();
            return _mapper.Map<List<CommonEntityVm>> (commonEntities);
        }
    }
}