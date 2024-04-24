using DataAccessLayer.Entity;
using DataAccessLayer.Interfaces;
using MongoDB.Driver;

namespace DataAccessLayer.Repositories;
public class TrainerRepository(IMongoCollection<Trainer> collection)
    : Repository<Trainer>(collection), ITrainerRepository
{
}