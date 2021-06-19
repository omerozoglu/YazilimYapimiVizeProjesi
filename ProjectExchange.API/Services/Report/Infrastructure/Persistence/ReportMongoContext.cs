using Domain.Entities;
using Infrastructure.Utilities.AppSettings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Persistence {
    public class ReportMongoContext : IMongoContext<Report> {

        //* MongoDbReportContext, MongoDb için gerekli ayarlamaları yapması ve asenkron bir şekilde komutları yürüttmesi için tasarlanmıştır

        #region MongoDb
        public IMongoCollection<Report> Collection { get; }
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _database;
        #endregion

        #region Settings
        private readonly MongoDbSettings _settings;
        #endregion

        public ReportMongoContext (IOptions<MongoDbSettings> options) {
            this._settings = options.Value;
            _mongoClient = new MongoClient (this._settings.ConnectionString);
            _database = _mongoClient.GetDatabase (this._settings.DatabaseName);
            Collection = _database.GetCollection<Report> (this._settings.CollectionName);
        }
    }
}