using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.DeleteCommand {
    public class DeleteCommonEntityCommandHandler : IRequestHandler<DeleteCommonEntityCommand, EntityResponse<CommonEntity>> {
        private readonly ICommonEntityRepository _commonEntityRepository;
        private readonly IMapper _mapper;

        public DeleteCommonEntityCommandHandler (ICommonEntityRepository commonEntityRepository, IMapper mapper) {
            _commonEntityRepository = commonEntityRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<CommonEntity>> Handle (DeleteCommonEntityCommand request, CancellationToken cancellationToken) {
            var response = new EntityResponse<CommonEntity> () { ReponseName = nameof (DeleteCommonEntityCommand), Content = new List<CommonEntity> () { } };
            var commonEntityToDelete = await _commonEntityRepository.GetByIdAsync (request.Id);
            if (commonEntityToDelete == null) {
                response.Status = ResponseType.Error;
                response.Message = "CommonEntity not found.";
                response.Content = null;
            } else {
                await _commonEntityRepository.DeleteAsync (commonEntityToDelete);
                response.Status = ResponseType.Success;
                response.Message = "CommonEntity deleted successfully.";
                response.Content.Add (commonEntityToDelete);
            }
            return response;
        }
    }
}