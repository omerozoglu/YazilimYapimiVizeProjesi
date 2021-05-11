using System.Collections.Generic;
using System.Threading.Tasks;
using ExchangeGateway.Models;

namespace ExchangeGateway.Services {
    public interface IProductService {
        Task<IEnumerable<ProductModel>> GetProductsByName (ProductModel model);
        Task<ProductModel> GetProduct (string id);
        Task<bool> UpdateProduct (ProductModel model);
        Task<ProductModel> CreateProduct (ProductModel model);

    }
}