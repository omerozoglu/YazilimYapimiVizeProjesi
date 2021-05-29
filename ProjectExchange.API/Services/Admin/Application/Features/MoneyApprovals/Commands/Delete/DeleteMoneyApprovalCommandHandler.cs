using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Features.MoneyApprovals.Commands.Delete {
    public class DeleteMoneyApprovalCommandHandler : IRequestHandler<DeleteMoneyApprovalCommand, EntityResponse<MoneyApproval>> {
        private readonly IApprovalEntityRepository<MoneyApproval> _approvalRepository;
        private readonly IMapper _mapper;

        public DeleteMoneyApprovalCommandHandler (IApprovalEntityRepository<MoneyApproval> approvalRepository, IMapper mapper) {
            _approvalRepository = approvalRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<MoneyApproval>> Handle (DeleteMoneyApprovalCommand request, CancellationToken cancellationToken) {
            var response = new EntityResponse<MoneyApproval> () { ReponseName = nameof (DeleteMoneyApprovalCommand), Content = new List<MoneyApproval> () { } };
            var entity = await _approvalRepository.GetOneAsync (p => p.Id == request.Id);
            if (entity == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"{nameof(MoneyApproval)} not found.";
                response.Content = null;
            } else {
                await _approvalRepository.DeleteAsync (entity);
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(MoneyApproval)} deleted successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}