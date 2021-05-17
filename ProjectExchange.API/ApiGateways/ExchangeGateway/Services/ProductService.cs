using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ExchangeGateway.Extensions;
using ExchangeGateway.Models;
using ExchangeGateway.Models.EntityModels;
using ExchangeGateway.Services.Interfaces;

namespace ExchangeGateway.Services {
    public class ProductService : IProductService {

        private readonly HttpClient _client;

        public ProductService (HttpClient client) {
            _client = client;
        }
        public async Task<ResponseModel<Product>> GetProduct (string id) {
            var response = await _client.GetAsync ($"/api/v1/Product/{id}");
            return await response.ReadContentAs<ResponseModel<Product>> ();
        }
        public async Task<ResponseModel<Product>> GetProductsByName (Product model) {
            var response = await _client.PostAsJsonAsync<Product> ($"/api/v1/Product/GetProductByName", model);
            return await response.ReadContentAs<ResponseModel<Product>> ();
        }
        public async Task<ResponseModel<Product>> CreateProduct (Product model) {
            var response = await _client.PostAsJsonAsync<Product> ($"/api/v1/Product", model);
            return await response.ReadContentAs<ResponseModel<Product>> ();;
        }
        public async Task<ResponseModel<Product>> UpdateProduct (Product model) {
            var response = await _client.PutAsJsonAsync<Product> ("/api/v1/Product", model);
            return await response.ReadContentAs<ResponseModel<Product>> ();
        }
    }
}