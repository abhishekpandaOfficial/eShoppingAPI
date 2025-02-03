using eShopping.API.Application.Features.Interfaces;
using eShopping.API.Domain.Entities;
using eShopping.API.Infrastructure.Persistence.DbContext;
using MediatR;

namespace eShopping.API.Application.Features.Products.Commands.Handlers;

/*
    The command handler will contain the logic for adding the product to the database. 
    It will use ApplicationDbContext to interact with the database and perform the actual database operations.
 */
public class AddProductHandler : IRequestHandler<AddProductCommand, Guid>
{
    private readonly IProductService _productService;
    // Injecting ApplicationDbContext through constructor
    public AddProductHandler(IProductService productService)
    {
       _productService = productService;
    }
    
    // Handling the command
    // Handling the command
    public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        // Assuming AddProductAsync returns the product ID after adding the product
        var productId = await _productService.AddProductAsync(request.Product);
        return productId;
    }
}