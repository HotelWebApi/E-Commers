using DataAccessLayer.Entity;

namespace DataAccessLayer.DTOs;
public class TrainerDto : BaseDto
{
    public string Brand { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public static implicit operator TrainerDto(Trainer trainer) 
        => new() 
        {
            Brand = trainer.Brand,
            Price = trainer.Price,
            ImageUrl = trainer.ImageUrl,
            Description = trainer.Description,
            Color = trainer.Color,
            Id = trainer.Id
        };
    public static implicit operator Trainer(TrainerDto trainer)
        => new()
        {
            Brand = trainer.Brand,
            Price = trainer.Price,
            ImageUrl = trainer.ImageUrl,
            Description = trainer.Description,
            Color = trainer.Color,
            Id = trainer.Id
        };
}