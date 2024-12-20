﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Application.DTOS;

public class OrderDto
{
    public DateTime Date { get; set; }
    
    [Required(ErrorMessage = "Name is required!")]
    [MinLength(3)]
    [MaxLength(100)]
    [DisplayName("Name")]
    public int TableNumber { get; set; }
    public decimal Total { get; set; }
}