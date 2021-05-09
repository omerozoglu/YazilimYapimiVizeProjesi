using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Utilities.AppSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Persistence {
    public class MongoDbUserContext : IMongoContext<User> {

        //* MongoDbUserContext, MongoDb için gerekli ayarlamaları yapması ve asenkron bir şekilde komutları yürüttmesi için tasarlanmıştır
        public IClientSessionHandle Session { get; set; }
        private readonly List<Func<Task>> _commands;

        #region MongoDb
        public MongoClient MongoClient { get; set; }
        public IMongoCollection<User> Collection { get; }
        private IMongoDatabase Database { get; set; }
        #endregion

        #region Settings
        private readonly MongoDbSettings _settings;
        private readonly IConfiguration _configuration;
        #endregion

        public MongoDbUserContext (IOptions<MongoDbSettings> options) {
            this._settings = options.Value;
            MongoClient = new MongoClient (this._settings.ConnectionString);
            Database = MongoClient.GetDatabase (this._settings.DatabaseName);
            Collection = Database.GetCollection<User> (this._settings.CollectionName);

            _commands = new List<Func<Task>> ();
        }
        public async Task<int> SaveChangesAsync () {
            using (Session = await MongoClient.StartSessionAsync ()) {
                Session.StartTransaction ();

                var commandTasks = _commands.Select (c => c ());

                await Task.WhenAll (commandTasks);

                await Session.CommitTransactionAsync ();
            }

            return _commands.Count;
        }
        public void AddCommand (Func<Task> func) {
            _commands.Add (func);
        }

    }
}