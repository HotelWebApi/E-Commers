namespace DataAccessLayer.Interfaces;
public interface IUnitOfWork
{
    ITrainerRepository TrainerRepository { get; }
}