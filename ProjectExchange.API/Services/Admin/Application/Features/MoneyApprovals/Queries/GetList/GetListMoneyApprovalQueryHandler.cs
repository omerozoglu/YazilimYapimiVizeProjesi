using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Features.MoneyApprovals.Queries.GetList;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Features.MoneyApprovals.Queries.GetListQuery {
    public class GetListMoneyApprovalQueryHandler : IRequestHandler<GetListMoneyApprovalQuery, EntityResponse<MoneyApproval>> {
        private readonly IApprovalEntityRepository<MoneyApproval> _approvalRepository;
        private readonly IMapper _mapper;

        public GetListMoneyApprovalQueryHandler (IApprovalEntityRepository<MoneyApproval> approvalRepository, IMapper mapper) {
            _approvalRepository = approvalRepository;
            _mapper = mapper;
        }
        public async Task<EntityResponse<MoneyApproval>> Handle (GetListMoneyApprovalQuery request, CancellationToken cancellationToken) {
            var response = new EntityResponse<MoneyApproval> () { ReponseName = nameof (GetListMoneyApprovalQuery), Content = new List<MoneyApproval> () { } };
            var entities = await _approvalRepository.GetAllAsync ();
            _mapper.Map<List<MoneyApproval>> (entities);
            if (entities == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"No {nameof(MoneyApproval)}s were found.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(MoneyApproval)}s get successfully.";
                response.Content.AddRange (entities);
            }
            return response;
        }
    }
}