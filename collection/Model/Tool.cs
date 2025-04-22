using System.ComponentModel.DataAnnotations;

namespace collection.Model;

public class Tool
{
    [Display(Name = "id")]
    public int Id { get; set; }
    
    [Display(Name = "name")]
    [Required(ErrorMessage = "Please assign a name to this tool.")]
    [MaxLength(200)]
    public required string Name { get; set; }

    [Display(Name = "brand")]
    [Required(ErrorMessage = "Please assign a brand name to this tool.")]
    public required Brand Brand { get; set; }

    [Display(Name = "description")]
    [MaxLength(1000000)]
    public string? Description { get; set; } = null;
    
    [Display(Name = "type")]
    [Required(ErrorMessage = "Please assign a type to this tool.")]
    [MaxLength(150)]
    public required string Type { get; set; }
    
    [Display(Name = "electrical")]
    [Required(ErrorMessage = "Please select an electrical option for this tool.")]
    public required bool Electrical { get; set; }
    
    [Display(Name = "product code")]
    [Required(ErrorMessage = "Please assign a product code this tool.")]
    [MaxLength(50)]
    public required string ProductCode { get; set; }
    
    [Display(Name = "ean 13")]
    [Required(ErrorMessage = "Please assign a ean 13 code to this tool.")]
    [MinLength(13)]
    [MaxLength(13)] // To fix warning on Ean13 for unlimited string length when using length
    public required string Ean13 { get; set; }
}
