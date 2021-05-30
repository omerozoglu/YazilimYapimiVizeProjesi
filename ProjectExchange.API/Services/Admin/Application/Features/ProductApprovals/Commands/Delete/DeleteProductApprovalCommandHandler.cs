using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductApprovals.Commands.Delete {
    public class DeleteProductApprovalCommandHandler : IRequestHandler<DeleteProductApprovalCommand, EntityResponse<ProductApproval>> {
        private readonly IApprovalEntityRepository<ProductApproval> _approvalRepository;
        private readonly IMapper _mapper;

        public DeleteProductApprovalCommandHandler (IApprovalEntityRepository<ProductApproval> approvalRepository, IMapper mapper) {
            _approvalRepository = approvalRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<ProductApproval>> Handle (DeleteProductApprovalCommand request, CancellationToken cancellationToken) {
            var response = new EntityResponse<ProductApproval> () { ReponseName = nameof (DeleteProductApprovalCommand), Content = new List<ProductApproval> () { } };
            var entity = await _approvalRepository.GetOneAsync (p => p.Id == request.Id);
            if (entity == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"{nameof(ProductApproval)} not found.";
                response.Content = null;
            } else {
                await _approvalRepository.DeleteAsync (entity);
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(ProductApproval)} deleted successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}