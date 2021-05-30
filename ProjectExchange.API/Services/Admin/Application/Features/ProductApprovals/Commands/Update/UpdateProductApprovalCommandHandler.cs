using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductApprovals.Commands.Update {
    public class UpdateProductApprovalCommandHandler : IRequestHandler<UpdateProductApprovalCommand, EntityResponse<ProductApproval>> {

        private readonly IApprovalEntityRepository<ProductApproval> _approvalRepository;
        private readonly IMapper _mapper;

        public UpdateProductApprovalCommandHandler (IApprovalEntityRepository<ProductApproval> approvalRepository, IMapper mapper) {
            _approvalRepository = approvalRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<ProductApproval>> Handle (UpdateProductApprovalCommand request, CancellationToken cancellationToken) {
            var response = new EntityResponse<ProductApproval> () { ReponseName = nameof (UpdateProductApprovalCommand), Content = new List<ProductApproval> () { } };
            var entity = await _approvalRepository.GetOneAsync (p => p.Id == request.Id);
            if (entity == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"{nameof(ProductApproval)} not found.";
                response.Content = null;
            } else {
                _mapper.Map (request, entity, typeof (UpdateProductApprovalCommand), typeof (ProductApproval));
                await _approvalRepository.UpdateAsync (entity);
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(ProductApproval)} updated successfully.";
                response.Content.Add (entity);
            }
            return response;
        }
    }
}