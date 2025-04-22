using System.ComponentModel.DataAnnotations;

namespace collection.Model;

public class Brand
{
    public int Id { get; set; }
    
    [Display(Name = "name")]
    [Required (ErrorMessage = "Please assign a name to this brand.")]
    [MaxLength(200)]
    public required string Name { get; set; }
}