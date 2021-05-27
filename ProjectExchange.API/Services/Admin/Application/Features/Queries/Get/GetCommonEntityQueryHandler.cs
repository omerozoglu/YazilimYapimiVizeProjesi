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
    public class GetCommonEntityQueryHandler<T> : IRequestHandler<GetCommonEntityQuery<T>, EntityResponse<CommonEntity<T>>> where T : ApprovalEntityBase {

        private readonly ICommonEntityRepository<T> _commonEntityRepository;
        private readonly IMapper _mapper;

        public GetCommonEntityQueryHandler (ICommonEntityRepository<T> commonEntityRepository, IMapper mapper) {
            _commonEntityRepository = commonEntityRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<CommonEntity<T>>> Handle (GetCommonEntityQuery<T> request, CancellationToken cancellationToken) {
            var response = new EntityResponse<CommonEntity<T>> () { ReponseName = nameof (GetCommonEntityQuery<T>), Content = new List<CommonEntity<T>> () { } };
            var entity = await _commonEntityRepository.GetOneAsync (p => p.Id == request.Id);
            entity = _mapper.Map<CommonEntity<T>> (entity);;
            if (entity == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"{nameof(CommonEntity<T>)} not found.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(CommonEntity<T>)} get successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}