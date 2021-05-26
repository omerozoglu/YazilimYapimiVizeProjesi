using Domain.Entities;
using Infrastructure.Utilities.AppSettings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Persistence {
    public class UserMongoContext : IMongoContext<User> {

        //* MongoDbUserContext, MongoDb için gerekli ayarlamaları yapması ve asenkron bir şekilde komutları yürüttmesi için tasarlanmıştır

        #region MongoDb
        public IMongoCollection<User> Collection { get; }
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _database;
        #endregion

        #region Settings
        private readonly MongoDbSettings _settings;
        #endregion

        public UserMongoContext (IOptions<MongoDbSettings> options) {
            this._settings = options.Value;
            _mongoClient = new MongoClient (this._settings.ConnectionString);
            _database = _mongoClient.GetDatabase (this._settings.DatabaseName);
            Collection = _database.GetCollection<User> (this._settings.CollectionName);
        }
    }
}