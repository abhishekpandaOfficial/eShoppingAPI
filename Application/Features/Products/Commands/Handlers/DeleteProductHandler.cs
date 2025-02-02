using eShopping.API.Infrastructure.Persistence.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eShopping.API.Application.Features.Products.Commands.Handlers;

public class DeleteProductHandler: IRequestHandler<DeleteProductCommand, bool>
{
    private readonly ApplicationDbContext _context;

    public DeleteProductHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        // Fetch the product from the database
        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == request.ProductId, cancellationToken);

        if (product == null)
        {
            // Product not found
            return false;
        }

        // Remove the product from the database
        _context.Products.Remove(product);

        // Save changes to the database
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}