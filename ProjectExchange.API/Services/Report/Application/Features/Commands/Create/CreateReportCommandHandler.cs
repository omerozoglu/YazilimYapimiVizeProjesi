using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.Create {
    public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, EntityResponse<Report>> {
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;

        public CreateReportCommandHandler (IReportRepository reportRepository, IMapper mapper) {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<Report>> Handle (CreateReportCommand request, CancellationToken cancellationToken) {
            var response = new EntityResponse<Report> () { ReponseName = nameof (CreateReportCommand), Content = new List<Report> () { } };
            var entity = _mapper.Map<Report> (request);
            var newentity = await _reportRepository.AddAsync (entity);
            if (newentity == null) {
                response.Status = ResponseType.Warning;
                response.Message = $"{nameof(Report)} could not be created.";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Report)} created successfully.";
                response.Content.Add (newentity);
            }
            return response;
        }
    }
}