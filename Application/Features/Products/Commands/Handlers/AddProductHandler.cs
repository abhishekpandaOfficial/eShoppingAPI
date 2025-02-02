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
    private readonly ApplicationDbContext _context;
    // Injecting ApplicationDbContext through constructor
    public AddProductHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    
    // Handling the command
    public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        // Creating new Product Entity
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
        };
        // Add the product to the context
        _context.Products.Add(product);
        // Save changes to the database
        await _context.SaveChangesAsync(cancellationToken);
        // Return the Id of the newly created product
        return product.Id;
    }
}