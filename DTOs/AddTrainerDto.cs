using DataAccessLayer.Entity;

namespace DataAccessLayer.DTOs;
public class AddTrainerDto 
{
    public string Brand { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public static implicit operator Trainer(AddTrainerDto car) => new()
    {
        Brand = car.Brand,
        Price = car.Price,
        ImageUrl = car.ImageUrl,
        Description = car.Description,
    };
}