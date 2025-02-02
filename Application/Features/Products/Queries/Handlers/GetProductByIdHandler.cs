using eShopping.API.Domain.Entities;
using eShopping.API.Infrastructure.Persistence.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eShopping.API.Application.Features.Products.Queries.Handlers;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly ApplicationDbContext _context;

    public GetProductByIdHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        // Retrieve the product from the database by Id
        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (product == null)
        {
            throw new KeyNotFoundException($"Product with Id {request.Id} not found.");
        }

        return product;
    }
}