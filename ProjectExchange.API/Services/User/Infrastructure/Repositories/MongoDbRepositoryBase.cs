using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Domain.Common;
using Infrastructure.Persistence;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Infrastructure.Repositories {
    public class MongoDbRepositoryBase<T> : IAsyncRepository<T> where T : EntityBase {

        //* MongoDbRepositoryBase, mongodb ile iletişimi sağlıyor

        protected readonly IMongoContext<T> _context;

        public MongoDbRepositoryBase (IMongoContext<T> context) {
            _context = context;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync () {
            return await _context.Collection.Find (x => true).ToListAsync ();
        }
        public async Task<T> GetByIdAsync (string id) {
            return await _context.Collection.Find (x => x.Id == id).FirstOrDefaultAsync ();
        }
        public async Task<T> AddAsync (T entity) {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            _context.AddCommand (() => _context.Collection.InsertOneAsync (entity, options));
            await _context.SaveChangesAsync ();
            return entity;
        }
        public async Task<T> UpdateAsync (T entity) {
            return await _context.Collection.FindOneAndReplaceAsync (x => x.Id == entity.Id, entity);
        }
        public async Task<T> DeleteAsync (T entity) {
            return await _context.Collection.FindOneAndDeleteAsync (x => x.Id == entity.Id);
        }
        public async Task<T> DeleteAsync (string id) {
            return await _context.Collection.FindOneAndDeleteAsync (x => x.Id == id);
        }
    }
}