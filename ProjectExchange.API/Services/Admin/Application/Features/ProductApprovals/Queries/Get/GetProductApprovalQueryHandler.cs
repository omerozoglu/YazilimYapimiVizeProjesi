using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Features.ProductApprovals.Queries.Get;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductApprovals.Queries.GetQuery {
    public class GetProductApprovalQueryHandler : IRequestHandler<GetProductApprovalQuery, EntityResponse<ProductApproval>> {

        private readonly IApprovalEntityRepository<ProductApproval> _approvalRepository;
        private readonly IMapper _mapper;

        public GetProductApprovalQueryHandler (IApprovalEntityRepository<ProductApproval> approvalRepository, IMapper mapper) {
            _approvalRepository = approvalRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<ProductApproval>> Handle (GetProductApprovalQuery request, CancellationToken cancellationToken) {
            var response = new EntityResponse<ProductApproval> () { ReponseName = nameof (GetProductApprovalQuery), Content = new List<ProductApproval> () { } };
            var entity = await _approvalRepository.GetOneAsync (p => p.Id == request.Id);
            entity = _mapper.Map<ProductApproval> (entity);;
            if (entity == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"{nameof(ProductApproval)} not found.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(ProductApproval)} get successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}