using Application.Contracts.Persistence;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories {
    public class ProductRepository : MongoDbRepositoryBase<Product>, IProductRepository {

        //* İhtiyaca yönelik Product repository
        public ProductRepository (MongoDbProductContext context) : base (context) {

        }
    }
}