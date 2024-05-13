using System.ComponentModel.DataAnnotations;

namespace PlatformService;

public class Platform
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Provider { get; set; }
    [Required]
    public decimal Cost { get; set; }
}
