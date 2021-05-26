using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Features.Queries.GetList;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetListQuery {
    public class GetListCommonEntityQueryHandler : IRequestHandler<GetListCommonEntityQuery, EntityResponse<CommonEntity>> {
        private readonly ICommonEntityRepository _commonEntityRepository;
        private readonly IMapper _mapper;

        public GetListCommonEntityQueryHandler (ICommonEntityRepository commonEntityRepository, IMapper mapper) {
            _commonEntityRepository = commonEntityRepository;
            _mapper = mapper;
        }
        public async Task<EntityResponse<CommonEntity>> Handle (GetListCommonEntityQuery request, CancellationToken cancellationToken) {
            var commonEntities = await _commonEntityRepository.GetAllAsync ();
            var response = new EntityResponse<CommonEntity> () { ReponseName = nameof (GetListCommonEntityQuery), Content = new List<CommonEntity> () { } };
            _mapper.Map<List<CommonEntity>> (commonEntities);
            if (commonEntities == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"No {nameof(CommonEntity)}s were found.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(CommonEntity)}s get successfully.";
                response.Content.AddRange (commonEntities);
            }
            return response;
        }
    }
}