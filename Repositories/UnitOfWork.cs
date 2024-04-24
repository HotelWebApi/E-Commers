using DataAccessLayer.Data;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories;
public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        TrainerRepository = new TrainerRepository(_dbContext.Trainers);
    }
    private readonly ApplicationDbContext _dbContext;
    public ITrainerRepository TrainerRepository { get; }
}