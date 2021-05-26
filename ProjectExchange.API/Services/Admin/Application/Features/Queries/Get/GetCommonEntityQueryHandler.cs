using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Features.Queries.Get;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetQuery {
    public class GetCommonEntityQueryHandler : IRequestHandler<GetCommonEntityQuery, EntityResponse<CommonEntity>> {

        private readonly ICommonEntityRepository _commonEntityRepository;
        private readonly IMapper _mapper;

        public GetCommonEntityQueryHandler (ICommonEntityRepository commonEntityRepository, IMapper mapper) {
            _commonEntityRepository = commonEntityRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<CommonEntity>> Handle (GetCommonEntityQuery request, CancellationToken cancellationToken) {
            var response = new EntityResponse<CommonEntity> () { ReponseName = nameof (GetCommonEntityQuery), Content = new List<CommonEntity> () { } };
            var entity = await _commonEntityRepository.GetOneAsync (p => p.Id == request.Id);
            entity = _mapper.Map<CommonEntity> (entity);;
            if (entity == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"{nameof(CommonEntity)} not found.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(CommonEntity)} get successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}