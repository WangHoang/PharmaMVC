using MongoDB.Driver;
using Microsoft.Extensions.Options;
using PharmaMVC.Models;

namespace PharmaMVC.Data.Settings
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Product> Products =>
            _database.GetCollection<Product>("Products");

        public IMongoCollection<User> Users =>
            _database.GetCollection<User>("Users");

        public IMongoCollection<Order> Orders =>
            _database.GetCollection<Order>("Orders");
    }
}
