using System.Net.Http;
using System.Threading.Tasks;
using ExchangeGateway.Extensions;
using ExchangeGateway.Models;

namespace ExchangeGateway.Services {
    public class UserService : IUserService {
        private readonly HttpClient _client;
        public UserService (HttpClient client) {
            _client = client;
        }

        public async Task<UserModel> GetUser (string id) {
            var response = await _client.GetAsync ($"/api/v1/User/{id}");
            return await response.ReadContentAs<UserModel> ();
        }

        public async Task<bool> UpdateUser (UpdateOnePropModel model) {
            var response = await _client.PutAsJsonAsync<UpdateOnePropModel> ("/api/v1/User/UpdateOneProp", model);
            return await response.ReadContentAs<bool> ();
        }

        public async Task<bool> UpdateUser (UserModel model) {
            var response = await _client.PutAsJsonAsync<UserModel> ("/api/v1/User/", model);
            return await response.ReadContentAs<bool> ();
        }
    }
}