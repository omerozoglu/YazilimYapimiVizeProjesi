using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ExchangeGateway.Extensions;
using ExchangeGateway.Models;

namespace ExchangeGateway.Services {
    public class ProductService : IProductService {

        private readonly HttpClient _client;

        public ProductService (HttpClient client) {
            _client = client;
        }

        public async Task<ProductModel> GetProduct (string id) {
            var response = await _client.GetAsync ($"/api/v1/Product/{id}");
            return await response.ReadContentAs<ProductModel> ();
        }

        public async Task<IEnumerable<ProductModel>> GetProductsByName (ProductModel model) {
            var response = await _client.PostAsJsonAsync<ProductModel> ($"/api/v1/Product/GetProductByName", model);
            return await response.ReadContentListAs<ProductModel> ();
        }
        public async Task<ProductModel> CreateProduct (ProductModel model) {
            var response = await _client.PostAsJsonAsync<ProductModel> ($"/api/v1/Product", model);
            return await response.ReadContentAs<ProductModel> ();;
        }

        public async Task<bool> UpdateProduct (ProductModel model) {
            var response = await _client.PutAsJsonAsync<ProductModel> ("/api/v1/Product", model);
            return await response.ReadContentAs<bool> ();
        }
    }
}