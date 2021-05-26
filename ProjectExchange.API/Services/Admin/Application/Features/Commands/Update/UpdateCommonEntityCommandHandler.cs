using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Update {
    public class UpdateCommonEntityCommandHandler : IRequestHandler<UpdateCommonEntityCommand, EntityResponse<CommonEntity>> {

        private readonly ICommonEntityRepository _commonEntityrepository;
        private readonly IMapper _mapper;

        public UpdateCommonEntityCommandHandler (ICommonEntityRepository commonEntityrepository, IMapper mapper) {
            _commonEntityrepository = commonEntityrepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<CommonEntity>> Handle (UpdateCommonEntityCommand request, CancellationToken cancellationToken) {

            var response = new EntityResponse<CommonEntity> () { ReponseName = nameof (UpdateCommonEntityCommand), Content = new List<CommonEntity> () { } };
            var entity = await _commonEntityrepository.GetOneAsync (p => p.Id == request.Id);
            if (entity == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"{nameof(CommonEntity)} not found.";
                response.Content = null;
            } else {
                _mapper.Map (request, entity, typeof (UpdateCommonEntityCommand), typeof (CommonEntity));
                await _commonEntityrepository.UpdateAsync (entity);
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(CommonEntity)} updated successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}