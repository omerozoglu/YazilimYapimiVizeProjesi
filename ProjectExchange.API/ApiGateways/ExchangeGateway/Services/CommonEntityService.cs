using System.Net.Http;
using System.Threading.Tasks;
using ExchangeGateway.Extensions;
using ExchangeGateway.Models;

namespace ExchangeGateway.Services {
    public class CommonEntityService : ICommonEntityService {

        private readonly HttpClient _client;
        public CommonEntityService (HttpClient client) {
            _client = client;
        }

        public async Task<CommonEntityModel> GetCommonEntity (string id) {
            var response = await _client.GetAsync ($"/api/v1/Admin/{id}");
            return await response.ReadContentAs<CommonEntityModel> ();
        }

        public async Task<bool> UpdateCommonEntity (CommonEntityModel model) {
            var response = await _client.PutAsJsonAsync<CommonEntityModel> ("/api/v1/Admin", model);
            return await response.ReadContentAs<bool> ();
        }
    }
}