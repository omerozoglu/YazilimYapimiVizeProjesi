using Domain.Common;
using Domain.Entities;
using Infrastructure.Utilities.AppSettings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Persistence {
    public class ApprovalEntityBaseMongoContext<T> : IMongoContext<T> where T : ApprovalEntityBase {

        //* MongoDbUserContext, MongoDb için gerekli ayarlamaları yapması ve asenkron bir şekilde komutları yürüttmesi için tasarlanmıştır

        #region MongoDb
        public IMongoCollection<T> Collection { get; }
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _database;
        private readonly string CollectionName;
        #endregion

        #region Settings
        private readonly MongoDbSettings _settings;
        #endregion

        public ApprovalEntityBaseMongoContext (IOptions<MongoDbSettings> options) {
            this._settings = options.Value;
            _mongoClient = new MongoClient (this._settings.ConnectionString);
            _database = _mongoClient.GetDatabase (this._settings.DatabaseName);
            if (typeof (T) == typeof (ProductApproval)) {
                this.CollectionName = "ProductApproval";
            } else {
                this.CollectionName = "MoneyApproval";
            }
            Collection = _database.GetCollection<T> (this.CollectionName);

        }
    }
}