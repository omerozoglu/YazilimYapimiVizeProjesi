using System;
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
            try {
                var response = await _client.GetAsync ($"/api/v1/Product/{id}");
                return await response.ReadContentAs<ResponseModel<Product>> ();
            } catch (Exception ex) {
                var response = new ResponseModel<Product> () {
                    ReponseName = nameof (GetProduct) + "in" + nameof (ExchangeGateway),
                    Message = ex.Message,
                    Status = ResponseType.Error,
                    Content = null
                };
                return response;
            }
        }
        public async Task<ResponseModel<Product>> GetProductsByName (string productName) {
            try {
                var response = await _client.GetAsync ($"/api/v1/Product/{productName}");
                return await response.ReadContentAs<ResponseModel<Product>> ();
            } catch (Exception ex) {
                var response = new ResponseModel<Product> () {
                    ReponseName = nameof (GetProductsByName) + "in" + nameof (ExchangeGateway),
                    Message = ex.Message,
                    Status = ResponseType.Error,
                    Content = null
                };
                return response;
            }
        }

        public async Task<ResponseModel<Product>> CreateProduct (Product model) {
            try {
                var response = await _client.PostAsJsonAsync<Product> ($"/api/v1/Product", model);
                return await response.ReadContentAs<ResponseModel<Product>> ();;
            } catch (Exception ex) {
                var response = new ResponseModel<Product> () {
                    ReponseName = nameof (CreateProduct) + "in" + nameof (ExchangeGateway),
                    Message = ex.Message,
                    Status = ResponseType.Error,
                    Content = null
                };
                return response;
            }
        }

        public async Task<ResponseModel<Product>> UpdateProduct (Product model) {
            try {
                var response = await _client.PutAsJsonAsync<Product> ("/api/v1/Product", model);
                return await response.ReadContentAs<ResponseModel<Product>> ();
            } catch (Exception ex) {
                var response = new ResponseModel<Product> () {
                    ReponseName = nameof (UpdateProduct) + "in" + nameof (ExchangeGateway),
                    Message = ex.Message,
                    Status = ResponseType.Error,
                    Content = null
                };
                return response;
            }
        }

        public async Task<ResponseModel<Product>> DeleteProduct (string id) {
            try {
                var response = await _client.DeleteAsJsonAsync ($"/api/v1/Product/{id}");
                return await response.ReadContentAs<ResponseModel<Product>> ();
            } catch (Exception ex) {
                var response = new ResponseModel<Product> () {
                    ReponseName = nameof (DeleteProduct) + "in" + nameof (ExchangeGateway),
                    Message = ex.Message,
                    Status = ResponseType.Error,
                    Content = null
                };
                return response;
            }
        }
    }
}