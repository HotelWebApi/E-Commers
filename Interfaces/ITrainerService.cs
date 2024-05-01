using DataAccessLayer.DTOs;

namespace DataAccessLayer.Interfaces;
public interface ITrainerService
{
    Task<IEnumerable<TrainerDto>> GetAllAsync();
    Task<TrainerDto> GetByIdAsync(string id);
    Task AddAsync(AddTrainerDto addTrainerDto);
    Task UpdateAsync(TrainerDto trainerDto);
    Task<IEnumerable<TrainerDto>> FilterByPriceAsync(decimal minPrice, decimal maxPrice);
    Task<IEnumerable<TrainerDto>> FilterByBrandAsync(string brand);
    Task<IEnumerable<TrainerDto>> FilterByColorAsync(string color);
    Task DeleteAsync(string id);
}