using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.CreateCommand {
    public class CreateCommonEntityCommandHandler : IRequestHandler<CreateCommonEntityCommand, EntityResponse<CommonEntity>> {

        private readonly ICommonEntityRepository _commonEntityRepository;
        private readonly IMapper _mapper;

        public CreateCommonEntityCommandHandler (ICommonEntityRepository commonEntityRepository, IMapper mapper) {
            _commonEntityRepository = commonEntityRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<CommonEntity>> Handle (CreateCommonEntityCommand request, CancellationToken cancellationToken) {
            var response = new EntityResponse<CommonEntity> () { ReponseName = nameof (CreateCommonEntityCommand), Content = new List<CommonEntity> () { } };
            var commonEntity = _mapper.Map<CommonEntity> (request);
            var newCommonEntity = await _commonEntityRepository.AddAsync (commonEntity);
            if (newCommonEntity == null) {
                response.Status = ResponseType.Error;
                response.Message = "CommonEntity could not be created.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = "CommonEntity created successfully.";
                response.Content.Add (newCommonEntity);
            }
            return response;
        }
    }
}