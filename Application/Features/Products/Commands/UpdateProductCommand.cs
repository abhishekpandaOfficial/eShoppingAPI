using eShopping.API.Application.Features.DTOs;
using MediatR;

namespace eShopping.API.Application.Features.Products.Commands;

public class UpdateProductCommand :IRequest<bool>
{
    public ProductDTO Product { get; set; }

    public UpdateProductCommand(ProductDTO product)
    {
        Product = product;
    }
}