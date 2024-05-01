using DataAccessLayer.Entity;

namespace DataAccessLayer.DTOs;
public class AddTrainerDto 
{
    public string Brand { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public static implicit operator Trainer(AddTrainerDto trainerDto) => new()
    {
        Brand = trainerDto.Brand,
        Price = trainerDto.Price,
        ImageUrl = trainerDto.ImageUrl,
        Description = trainerDto.Description,
        Color = trainerDto.Color
    };
}