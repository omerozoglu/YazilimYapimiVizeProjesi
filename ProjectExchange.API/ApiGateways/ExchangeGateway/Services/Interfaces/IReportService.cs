using System.Threading.Tasks;
using Domain.Entities;
using ExchangeGateway.Models;

namespace ExchangeGateway.Services.Interfaces {
    public interface IReportService {
        Task<ResponseModel<Report>> GetReports ();
        Task<ResponseModel<Report>> CreateReport (Report model);

    }
}