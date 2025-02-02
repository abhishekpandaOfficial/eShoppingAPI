using eShopping.API.Domain.ValueObjects;
using eShopping.API.Infrastructure.Persistence.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eShopping.API.Application.Features.Products.Commands.Handlers;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly ApplicationDbContext _context;

    public UpdateProductHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        // Fetch the product from the database
        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == request.ProductId, cancellationToken);

        if (product == null)
        {
            // Product not found
            return false;
        }

        // Update product properties
        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = new Money(request.Amount, request.Currency);  // Update the price with the new Money object

        // Save changes to the database
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}