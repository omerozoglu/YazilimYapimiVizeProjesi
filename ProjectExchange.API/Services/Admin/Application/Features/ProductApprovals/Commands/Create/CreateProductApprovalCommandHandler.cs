using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductApprovals.Commands.Create {
    public class CreateProductApprovalCommandHandler : IRequestHandler<CreateProductApprovalCommand, EntityResponse<ProductApproval>> {

        private readonly IApprovalEntityRepository<ProductApproval> _approvalRepository;
        private readonly IMapper _mapper;

        public CreateProductApprovalCommandHandler (IApprovalEntityRepository<ProductApproval> approvalRepository, IMapper mapper) {
            _approvalRepository = approvalRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<ProductApproval>> Handle (CreateProductApprovalCommand request, CancellationToken cancellationToken) {
            var response = new EntityResponse<ProductApproval> () { ReponseName = nameof (CreateProductApprovalCommand), Content = new List<ProductApproval> () { } };
            var entity = _mapper.Map<ProductApproval> (request);
            var newentity = await _approvalRepository.AddAsync (entity);
            if (newentity == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"{nameof(ProductApproval)} could not be created.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(ProductApproval)} created successfully.";
                response.Content.Add (newentity);
            }
            return response;
        }
    }
}