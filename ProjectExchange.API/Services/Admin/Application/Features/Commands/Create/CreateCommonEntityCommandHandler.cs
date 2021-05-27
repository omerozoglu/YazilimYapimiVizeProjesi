using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Create {
    public class CreateCommonEntityCommandHandler<T> : IRequestHandler<CreateCommonEntityCommand<T>, EntityResponse<CommonEntity<T>>> where T : ApprovalEntityBase {

        private readonly ICommonEntityRepository<T> _commonEntityRepository;
        private readonly IMapper _mapper;

        public CreateCommonEntityCommandHandler (ICommonEntityRepository<T> commonEntityRepository, IMapper mapper) {
            _commonEntityRepository = commonEntityRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<CommonEntity<T>>> Handle (CreateCommonEntityCommand<T> request, CancellationToken cancellationToken) {
            var response = new EntityResponse<CommonEntity<T>> () { ReponseName = nameof (CreateCommonEntityCommand<T>), Content = new List<CommonEntity<T>> () { } };
            var entity = _mapper.Map<CommonEntity<T>> (request);
            var newentity = await _commonEntityRepository.AddAsync (entity);
            if (newentity == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"{nameof(CommonEntity<T>)} could not be created.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(CommonEntity<T>)} created successfully.";
                response.Content.Add (newentity);
            }
            return response;
        }
    }
}