using DataAccessLayer.DTOs;
using DataAccessLayer.Commens.Helpers;
using DataAccessLayer.Entity;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Services;

public class TrainerService(IUnitOfWork unitOfWork) : ITrainerService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task AddAsync(AddTrainerDto addTrainerDto)
    {
        if (addTrainerDto == null)
        {
            throw new ArgumentNullException(nameof(addTrainerDto));
        }
        if(addTrainerDto.Brand == null)
        {
            throw new ArgumentNullException("Brand cannot be null");
        }
        if(addTrainerDto.Price <= 0)
        {
            throw new Exception("Price cannot be less than or equal to zero");
        }
        var trainers = await _unitOfWork.TrainerRepository.GetAllAsync();
        var trainer = (Trainer)addTrainerDto;
        if (trainer.IsExist(trainers))
        {
            throw new Exception("Trainer already exist");
        }
        await _unitOfWork.TrainerRepository.AddAsync(trainer);
    }

    public async Task DeleteAsync(string id)
    {
        await _unitOfWork.TrainerRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<TrainerDto>> GetAllAsync()
    {
        var trainers = await _unitOfWork.TrainerRepository.GetAllAsync();
        return trainers.Select(x => (TrainerDto)x).ToList();
    }

    public async Task<TrainerDto> GetByIdAsync(string id)
    {
        var tariner = await _unitOfWork.TrainerRepository.GetByIdAsync(id);
        return (TrainerDto)tariner;
    }

    public async Task UpdateAsync(TrainerDto trainerDto)
    {
        if (trainerDto == null)
        {
            throw new ArgumentNullException(nameof(trainerDto));
        }
        if (trainerDto.Brand == null)
        {
            throw new ArgumentNullException("Brand cannot be null");
        }
        if (trainerDto.Price <= 0)
        {
            throw new Exception("Price cannot be less than or equal to zero");
        }
        var trainers = await _unitOfWork.TrainerRepository.GetAllAsync();
        var trainer = (Trainer)trainerDto;
        if (trainer.IsExist(trainers))
        {
            throw new Exception("Trainer already exist");
        }
        await _unitOfWork.TrainerRepository.UpdateAsync(trainer);
    }
}