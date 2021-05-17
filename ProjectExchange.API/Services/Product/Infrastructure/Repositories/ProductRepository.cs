using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Domain.Entities;
using Infrastructure.Persistence;
using MongoDB.Driver;

namespace Infrastructure.Repositories {
    public class ProductRepository : MongoDbRepositoryBase<Product>, IProductRepository {

        //* İhtiyaca yönelik Product repository
        public ProductRepository (MongoDbProductContext context) : base (context) {

        }

        public async Task<IReadOnlyList<Product>> GetAllGroupedAsync () {
            var counter = 0;
            var products = new List<Product> ();
            var result = new List<Product> ();
            try {
                var groupedProductList = await _context.Collection.Aggregate ().Group (i => i.Name, g => new Product () { Name = g.First ().Name, ImgUrl = g.First ().ImgUrl, Weight = g.First ().Weight, UnitPrice = g.First ().UnitPrice }).ToListAsync ();
                foreach (var item in groupedProductList) {
                    if (item.UnitPrice != 0)
                        result.Add (item);
                    else { continue; }
                }
                foreach (var groupedProduct in result) {
                    products = await _context.Collection.Find (x => (x.Name == groupedProduct.Name) && (x.UnitPrice != 0)).ToListAsync ();
                    if (products.Count < 1) {
                        continue;
                    }
                    result.Find (x => x.Name == groupedProduct.Name).Weight = 0;
                    result.Find (x => x.Name == groupedProduct.Name).UnitPrice = 0;
                    var tempUnitPrice = 0.0;
                    foreach (Product namedProduct in products) {
                        result.Find (x => x.Name == namedProduct.Name).Weight += namedProduct.Weight;
                        result.Find (x => x.Name == groupedProduct.Name).Id = products.First ().Id;
                        tempUnitPrice += namedProduct.UnitPrice;
                        counter++;
                    }
                    result.Find (x => x.Name == groupedProduct.Name).UnitPrice = Math.Round (tempUnitPrice, 2) / counter;
                    counter = 0;
                    tempUnitPrice = 0;
                }
                return result;
            } catch (System.Exception) {

                throw;
            }

        }
    }
}