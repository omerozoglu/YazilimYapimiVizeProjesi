using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.UpdateCommand {
    public class UpdateCommonEntityCommandHandler : IRequestHandler<UpdateCommonEntityCommand, EntityResponse<CommonEntity>> {

        private readonly ICommonEntityRepository _commonEntityrepository;
        private readonly IMapper _mapper;

        public UpdateCommonEntityCommandHandler (ICommonEntityRepository commonEntityrepository, IMapper mapper) {
            _commonEntityrepository = commonEntityrepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<CommonEntity>> Handle (UpdateCommonEntityCommand request, CancellationToken cancellationToken) {

            var response = new EntityResponse<CommonEntity> () { ReponseName = nameof (UpdateCommonEntityCommand), Content = new List<CommonEntity> () { } };
            var commonEntityToUpdate = await _commonEntityrepository.GetByIdAsync (request.Id);
            if (commonEntityToUpdate == null) {
                response.Status = ResponseType.Error;
                response.Message = "CommonEntity not found.";
                response.Content = null;
            } else {
                _mapper.Map (request, commonEntityToUpdate, typeof (UpdateCommonEntityCommand), typeof (CommonEntity));
                await _commonEntityrepository.UpdateAsync (commonEntityToUpdate);
                response.Status = ResponseType.Success;
                response.Message = "CommonEntity updated successfully.";
                response.Content.Add (commonEntityToUpdate);
            }
            return response;
        }
    }
}