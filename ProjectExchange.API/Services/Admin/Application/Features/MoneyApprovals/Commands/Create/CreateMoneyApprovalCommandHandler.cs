using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Features.MoneyApprovals.Commands.Create {
    public class CreateMoneyApprovalCommandHandler : IRequestHandler<CreateMoneyApprovalCommand, EntityResponse<MoneyApproval>> {

        private readonly IApprovalEntityRepository<MoneyApproval> _approvalRepository;
        private readonly IMapper _mapper;

        public CreateMoneyApprovalCommandHandler (IApprovalEntityRepository<MoneyApproval> approvalRepository, IMapper mapper) {
            _approvalRepository = approvalRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<MoneyApproval>> Handle (CreateMoneyApprovalCommand request, CancellationToken cancellationToken) {
            var response = new EntityResponse<MoneyApproval> () { ReponseName = nameof (CreateMoneyApprovalCommand), Content = new List<MoneyApproval> () { } };
            var entity = _mapper.Map<MoneyApproval> (request);
            var newentity = await _approvalRepository.AddAsync (entity);
            if (newentity == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"{nameof(MoneyApproval)} could not be created.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(MoneyApproval)} created successfully.";
                response.Content.Add (newentity);
            }
            return response;
        }
    }
}