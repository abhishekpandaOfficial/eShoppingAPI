using eShopping.API.Domain.ValueObjects;
using FluentAssertions.Equivalency;

namespace eShopping.API.Application.Features.DTOs;

public class ProductDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}