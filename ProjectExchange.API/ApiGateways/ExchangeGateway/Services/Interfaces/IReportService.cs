using System.Threading.Tasks;
using Domain.Entities;
using ExchangeGateway.Models;
using ExchangeGateway.Models.EntityModels;

namespace ExchangeGateway.Services.Interfaces {
    public interface IReportService {
        Task<ResponseModel<Report>> GetReports ();
        Task<ResponseModel<Report>> CreateReport (Report model);

    }
}