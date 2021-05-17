namespace Infrastructure.Utilities.AppSettings {
    public class MongoDbSettings {
        public string ConnectionString;
        public string DatabaseName;
        public string CollectionName;

        //for Configuration
        #region Const Values

        public const string ConnectionStringValue = nameof (ConnectionString);
        public const string DatabaseValue = nameof (DatabaseName);
        public const string CollectionValue = nameof (CollectionName);

        #endregion
    }
}