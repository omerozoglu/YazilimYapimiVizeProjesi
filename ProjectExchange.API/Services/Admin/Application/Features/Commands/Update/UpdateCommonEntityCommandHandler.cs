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
    public class UpdateCommonEntityCommandHandler<T> : IRequestHandler<UpdateCommonEntityCommand<T>, EntityResponse<CommonEntity<T>>> where T : ApprovalEntityBase {

        private readonly ICommonEntityRepository<T> _commonEntityrepository;
        private readonly IMapper _mapper;

        public UpdateCommonEntityCommandHandler (ICommonEntityRepository<T> commonEntityrepository, IMapper mapper) {
            _commonEntityrepository = commonEntityrepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<CommonEntity<T>>> Handle (UpdateCommonEntityCommand<T> request, CancellationToken cancellationToken) {

            var response = new EntityResponse<CommonEntity<T>> () { ReponseName = nameof (UpdateCommonEntityCommand<T>), Content = new List<CommonEntity<T>> () { } };
            var entity = await _commonEntityrepository.GetOneAsync (p => p.Id == request.Id);
            if (entity == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"{nameof(CommonEntity<T>)} not found.";
                response.Content = null;
            } else {
                _mapper.Map (request, entity, typeof (UpdateCommonEntityCommand<T>), typeof (CommonEntity<T>));
                await _commonEntityrepository.UpdateAsync (entity);
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(CommonEntity<T>)} updated successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}