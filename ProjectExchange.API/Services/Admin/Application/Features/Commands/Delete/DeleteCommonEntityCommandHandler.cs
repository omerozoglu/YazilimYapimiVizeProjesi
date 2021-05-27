using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Delete {
    public class DeleteCommonEntityCommandHandler<T> : IRequestHandler<DeleteCommonEntityCommand<T>, EntityResponse<CommonEntity<T>>> where T : ApprovalEntityBase {
        private readonly ICommonEntityRepository<T> _commonEntityRepository;
        private readonly IMapper _mapper;

        public DeleteCommonEntityCommandHandler (ICommonEntityRepository<T> commonEntityRepository, IMapper mapper) {
            _commonEntityRepository = commonEntityRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<CommonEntity<T>>> Handle (DeleteCommonEntityCommand<T> request, CancellationToken cancellationToken) {
            var response = new EntityResponse<CommonEntity<T>> () { ReponseName = nameof (DeleteCommonEntityCommand<T>), Content = new List<CommonEntity<T>> () { } };
            var entity = await _commonEntityRepository.GetOneAsync (p => p.Id == request.Id);
            if (entity == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"{nameof(CommonEntity<T>)} not found.";
                response.Content = null;
            } else {
                await _commonEntityRepository.DeleteAsync (entity);
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(CommonEntity<T>)} deleted successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}