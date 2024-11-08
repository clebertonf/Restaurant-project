using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.DTOS;

public class MenuItemDto
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Name is required!")]
    [MinLength(3)]
    [MaxLength(100)]
    [DisplayName("Name")]
    public string? Name { get; set; }
    
    [Required(ErrorMessage = "Description is required!")]
    [MinLength(5)]
    [MaxLength(200)]
    [DisplayName("Description")]
    public string? Description { get; set; }
    
    [Required(ErrorMessage = "Price is required!")]
    [Column(TypeName = "decimal(18,2)")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    [DataType(DataType.Currency)]
    [DisplayName("Price")]
    public decimal Price { get; set; }
    
    public bool Available { get; set; } = default;
    
    public Order? Order { get; set; }
}