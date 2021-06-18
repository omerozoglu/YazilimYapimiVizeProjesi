using System.Threading.Tasks;
using ExchangeGateway.Models;
using ExchangeGateway.Models.EntityModels;

namespace ExchangeGateway.Services.Interfaces {
    public interface IProductService {
        Task<ResponseModel<Product>> GetProductsByName (string model);
        Task<ResponseModel<Product>> GetProduct (string id);
        Task<ResponseModel<Product>> UpdateProduct (Product model);
        Task<ResponseModel<Product>> CreateProduct (Product model);
        Task<ResponseModel<Product>> DeleteProduct (string id);
        Task<ResponseModel<Product>> GetProductsWithStatusByName (string productName);
    }
}