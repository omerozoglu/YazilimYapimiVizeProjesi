using System.Net.Http;
using System.Threading.Tasks;
using ExchangeGateway.Extensions;
using ExchangeGateway.Models;
using ExchangeGateway.Models.EntityModels;
using ExchangeGateway.Services.Interfaces;

namespace ExchangeGateway.Services {
    public class UserService : IUserService {
        private readonly HttpClient _client;
        public UserService (HttpClient client) {
            _client = client;
        }
        public async Task<ResponseModel<User>> GetUser (string id) {
            var response = await _client.GetAsync ($"/api/v1/User/{id}");
            return await response.ReadContentAs<ResponseModel<User>> ();
        }
        public async Task<ResponseModel<User>> UpdateUser (User model) {
            var response = await _client.PutAsJsonAsync<User> ("/api/v1/User/", model);
            return await response.ReadContentAs<ResponseModel<User>> ();
        }
    }
}