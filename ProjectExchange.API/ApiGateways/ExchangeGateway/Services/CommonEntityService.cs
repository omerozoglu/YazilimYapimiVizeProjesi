using System.Net.Http;
using System.Threading.Tasks;
using ExchangeGateway.Extensions;
using ExchangeGateway.Models;
using ExchangeGateway.Models.EntityModels;
using ExchangeGateway.Services.Interfaces;

namespace ExchangeGateway.Services {
    public class CommonEntityService : ICommonEntityService {

        private readonly HttpClient _client;
        public CommonEntityService (HttpClient client) {
            _client = client;
        }

        public async Task<ResponseModel<Admin>> GetCommonEntity (string id) {
            var response = await _client.GetAsync ($"/api/v1/Admin/{id}");
            return await response.ReadContentAs<ResponseModel<Admin>> ();
        }
        public async Task<ResponseModel<Admin>> CreateCommonEntity (Admin model) {
            var response = await _client.PostAsJsonAsync<Admin> ("/api/v1/Admin", model);
            return await response.ReadContentAs<ResponseModel<Admin>> ();
        }

        public async Task<ResponseModel<Admin>> UpdateCommonEntity (Admin model) {
            var response = await _client.PutAsJsonAsync<Admin> ("/api/v1/Admin", model);
            return await response.ReadContentAs<ResponseModel<Admin>> ();
        }
    }
}