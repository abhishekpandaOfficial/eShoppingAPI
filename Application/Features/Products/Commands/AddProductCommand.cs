using eShopping.API.Application.Features.DTOs;
using eShopping.API.Domain.ValueObjects;
using MediatR;

namespace eShopping.API.Application.Features.Products.Commands;

public class AddProductCommand :IRequest<Guid>
{
    public ProductDTO Product { get; set; }
    public AddProductCommand(ProductDTO product)
    {
        Product = product;
    }
}