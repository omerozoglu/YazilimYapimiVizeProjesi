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
    public class DeleteCommonEntityCommandHandler : IRequestHandler<DeleteCommonEntityCommand, EntityResponse<CommonEntity>> {
        private readonly ICommonEntityRepository _commonEntityRepository;
        private readonly IMapper _mapper;

        public DeleteCommonEntityCommandHandler (ICommonEntityRepository commonEntityRepository, IMapper mapper) {
            _commonEntityRepository = commonEntityRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<CommonEntity>> Handle (DeleteCommonEntityCommand request, CancellationToken cancellationToken) {
            var response = new EntityResponse<CommonEntity> () { ReponseName = nameof (DeleteCommonEntityCommand), Content = new List<CommonEntity> () { } };
            var entity = await _commonEntityRepository.GetOneAsync (p => p.Id == request.Id);
            if (entity == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"{nameof(CommonEntity)} not found.";
                response.Content = null;
            } else {
                await _commonEntityRepository.DeleteAsync (entity);
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(CommonEntity)} deleted successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}