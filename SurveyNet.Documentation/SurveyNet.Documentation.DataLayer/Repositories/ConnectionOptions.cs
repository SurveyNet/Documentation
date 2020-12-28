namespace SurveyNet.Documentation.DataLayer.Repositories {
    public record ConnectionOptions {
        public ConnectionOptions(string connectionString) {
            ConnectionString = connectionString;
        }
        public string ConnectionString { get; }
    }
}