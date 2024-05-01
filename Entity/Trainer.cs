using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entity;
public class Trainer : BaseEntity
{
    [Required, StringLength(20)]
    public string Brand { get; set; } = string.Empty;
    [Required, StringLength(15)]
    public string Color { get; set; } = string.Empty;
    [Required, StringLength(30)]
    public decimal Price { get; set; }
    [Required]
    public string ImageUrl { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
}