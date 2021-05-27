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
    public class GetListCommonEntityQueryHandler<T> : IRequestHandler<GetListCommonEntityQuery<T>, EntityResponse<CommonEntity<T>>> where T : ApprovalEntityBase {
        private readonly ICommonEntityRepository<T> _commonEntityRepository;
        private readonly IMapper _mapper;

        public GetListCommonEntityQueryHandler (ICommonEntityRepository<T> commonEntityRepository, IMapper mapper) {
            _commonEntityRepository = commonEntityRepository;
            _mapper = mapper;
        }
        public async Task<EntityResponse<CommonEntity<T>>> Handle (GetListCommonEntityQuery<T> request, CancellationToken cancellationToken) {
            var commonEntities = await _commonEntityRepository.GetAllAsync ();
            var response = new EntityResponse<CommonEntity<T>> () { ReponseName = nameof (GetListCommonEntityQuery<T>), Content = new List<CommonEntity<T>> () { } };
            _mapper.Map<List<CommonEntity<T>>> (commonEntities);
            if (commonEntities == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"No {nameof(CommonEntity<T>)}s were found.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(CommonEntity<T>)}s get successfully.";
                response.Content.AddRange (commonEntities);
            }
            return response;
        }
    }
}