using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Domain.Entities;
using Infrastructure.Persistence;
using MongoDB.Driver;

namespace Infrastructure.Repositories {
    public class ProductRepository : MongoDBRepositoryBase<Product>, IProductRepository {

        //* İhtiyaca yönelik Product repository
        public ProductRepository (ProductMongoContext context) : base (context) {

        }

        public async Task<IReadOnlyList<Product>> GetAllGroupedAsync () {
            double tmpweight = 0;
            var result = new List<Product> ();
            try {
                var productList = await _context.Collection.Find (p => (p.UnitPrice != 0) && (p.Status == 1)).ToListAsync ();
                var groupedProductList = productList.GroupBy (p => p.Name, (Key, g) => new Product () { UserId = g.First ().UserId, Name = g.First ().Name, ImgUrl = g.First ().ImgUrl, Weight = g.First ().Weight, UnitPrice = g.First ().UnitPrice });
                foreach (var item in groupedProductList) {
                    var products = productList.FindAll (p => p.Name == item.Name);
                    products.ForEach (p => tmpweight += p.Weight);
                    item.Weight = tmpweight;
                    result.Add (item);
                    tmpweight = 0;
                }

                return result;
            } catch (Exception) {

                return result;
            }

        }
    }
}