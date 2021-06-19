using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Common;
using Domain.Common.Enums;
using Domain.Entities;
using MediatR;

namespace Application.Features.Queries.GetList {
    public class GetReportsListQueryHandler : IRequestHandler<GetReportsListQuery, EntityResponse<Report>> {
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;

        public GetReportsListQueryHandler (IReportRepository reportRepository, IMapper mapper) {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        public async Task<EntityResponse<Report>> Handle (GetReportsListQuery request, CancellationToken cancellationToken) {
            var response = new EntityResponse<Report> () { ReponseName = nameof (GetReportsListQuery), Content = new List<Report> () { } };
            var ReportList = await _reportRepository.GetAllAsync ();
            _mapper.Map<List<Report>> (ReportList);
            if (ReportList == null) {
                response.Status = ResponseType.Error;
                response.Message = $"No {nameof(Report)}s were found .";
                response.Content = null;
            } else {
                response.Status = ResponseType.Success;
                response.Message = $"{nameof(Report)}s get successfully.";
                response.Content.AddRange (ReportList);
            }
            return response;
        }
    }
}