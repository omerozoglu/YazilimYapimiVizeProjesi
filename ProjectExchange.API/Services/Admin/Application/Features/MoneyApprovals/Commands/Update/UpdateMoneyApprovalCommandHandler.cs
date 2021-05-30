using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Features.MoneyApprovals.Commands.Update {
    public class UpdateMoneyApprovalCommandHandler : IRequestHandler<UpdateMoneyApprovalCommand, EntityResponse<MoneyApproval>> {

        private readonly IApprovalEntityRepository<MoneyApproval> _approvalRepository;
        private readonly IMapper _mapper;

        public UpdateMoneyApprovalCommandHandler (IApprovalEntityRepository<MoneyApproval> approvalRepository, IMapper mapper) {
            _approvalRepository = approvalRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<MoneyApproval>> Handle (UpdateMoneyApprovalCommand request, CancellationToken cancellationToken) {
            var response = new EntityResponse<MoneyApproval> () { ReponseName = nameof (UpdateMoneyApprovalCommand), Content = new List<MoneyApproval> () { } };
            var entity = await _approvalRepository.GetOneAsync (p => p.Id == request.Id);
            if (entity == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"{nameof(MoneyApproval)} not found.";
                response.Content = null;
            } else {
                _mapper.Map (request, entity, typeof (UpdateMoneyApprovalCommand), typeof (MoneyApproval));
                await _approvalRepository.UpdateAsync (entity);
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(MoneyApproval)} updated successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}