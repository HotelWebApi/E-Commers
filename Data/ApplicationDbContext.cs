using DataAccessLayer.Entity;
using MongoDB.Driver;

namespace DataAccessLayer.Data;
public class ApplicationDbContext
{
    private readonly IMongoDatabase _database;
    public ApplicationDbContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }
    public IMongoCollection<Trainer> Trainers =>
        _database.GetCollection<Trainer>("Krofofkalar");
}