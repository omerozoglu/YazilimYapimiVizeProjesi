using System;
using System.Net.Http;
using System.Threading.Tasks;
using Domain.Entities;
using ExchangeGateway.Extensions;
using ExchangeGateway.Models;
using ExchangeGateway.Services.Interfaces;

namespace ExchangeGateway.Services {
    public class ReportService : IReportService {

        private readonly HttpClient _client;
        public ReportService (HttpClient client) {
            _client = client;
        }
        public async Task<ResponseModel<Report>> GetReports () {
            try {
                var response = await _client.GetAsync ($"/api/v1/Report");
                return await response.ReadContentAs<ResponseModel<Report>> ();

            } catch (Exception ex) {
                var response = new ResponseModel<Report> () {
                    ReponseName = nameof (GetReports) + "in" + nameof (ExchangeGateway),
                    Message = ex.Message,
                    Status = ResponseStatus.Error,
                    Content = null
                };
                return response;
            }
        }
        public async Task<ResponseModel<Report>> CreateReport (Report model) {
            try {
                var response = await _client.PostAsJsonAsync<Report> ($"/api/v1/Report", model);
                return await response.ReadContentAs<ResponseModel<Report>> ();;
            } catch (Exception ex) {
                var response = new ResponseModel<Report> () {
                    ReponseName = nameof (CreateReport) + "in" + nameof (ExchangeGateway),
                    Message = ex.Message,
                    Status = ResponseStatus.Error,
                    Content = null
                };
                return response;
            }
        }

    }
}