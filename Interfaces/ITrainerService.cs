using DataAccessLayer.DTOs;

namespace DataAccessLayer.Interfaces;
public interface ITrainerService
{
    Task<IEnumerable<TrainerDto>> GetAllAsync();
    Task<TrainerDto> GetByIdAsync(string id);
    Task AddAsync(AddTrainerDto addTrainerDto);
    Task UpdateAsync(TrainerDto trainerDto);
    Task DeleteAsync(string id);
}