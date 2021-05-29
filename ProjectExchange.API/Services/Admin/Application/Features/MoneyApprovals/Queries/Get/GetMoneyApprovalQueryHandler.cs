using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Features.MoneyApprovals.Queries.Get;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Features.MoneyApprovals.Queries.GetQuery {
    public class GetMoneyApprovalQueryHandler : IRequestHandler<GetMoneyApprovalQuery, EntityResponse<MoneyApproval>> {

        private readonly IApprovalEntityRepository<MoneyApproval> _approvalRepository;
        private readonly IMapper _mapper;

        public GetMoneyApprovalQueryHandler (IApprovalEntityRepository<MoneyApproval> approvalRepository, IMapper mapper) {
            _approvalRepository = approvalRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<MoneyApproval>> Handle (GetMoneyApprovalQuery request, CancellationToken cancellationToken) {
            var response = new EntityResponse<MoneyApproval> () { ReponseName = nameof (GetMoneyApprovalQuery), Content = new List<MoneyApproval> () { } };
            var entity = await _approvalRepository.GetOneAsync (p => p.Id == request.Id);
            entity = _mapper.Map<MoneyApproval> (entity);;
            if (entity == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"{nameof(MoneyApproval)} not found.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(MoneyApproval)} get successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}