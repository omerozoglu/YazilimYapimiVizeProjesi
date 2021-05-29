using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Features.ProductApprovals.Queries.GetList;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductApprovals.Queries.GetListQuery {
    public class GetListProductApprovalQueryHandler : IRequestHandler<GetListProductApprovalQuery, EntityResponse<ProductApproval>> {
        private readonly IApprovalEntityRepository<ProductApproval> _approvalRepository;
        private readonly IMapper _mapper;

        public GetListProductApprovalQueryHandler (IApprovalEntityRepository<ProductApproval> approvalRepository, IMapper mapper) {
            _approvalRepository = approvalRepository;
            _mapper = mapper;
        }
        public async Task<EntityResponse<ProductApproval>> Handle (GetListProductApprovalQuery request, CancellationToken cancellationToken) {
            var response = new EntityResponse<ProductApproval> () { ReponseName = nameof (GetListProductApprovalQuery), Content = new List<ProductApproval> () { } };
            var entities = await _approvalRepository.GetAllAsync ();
            _mapper.Map<List<ProductApproval>> (entities);
            if (entities == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"No {nameof(ProductApproval)}s were found.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(ProductApproval)}s get successfully.";
                response.Content.AddRange (entities);
            }
            return response;
        }
    }
}