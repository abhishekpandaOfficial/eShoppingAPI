using eShopping.API.Domain.Entities;
using eShopping.API.Infrastructure.Persistence.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eShopping.API.Application.Features.Products.Queries.Handlers;

public class GetProductsHandler: IRequestHandler<GetProductsQuery, List<Product>>
{
    private readonly ApplicationDbContext _context;

    public GetProductsHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        // Query the Products table based on query parameters like Name and Currency.
        var query = _context.Products.AsQueryable();

        if (!string.IsNullOrEmpty(request.Name))
        {
            query = query.Where(p => p.Name.Contains(request.Name)); // Optional filtering by product name
        }

        if (!string.IsNullOrEmpty(request.Currency))
        {
            query = query.Where(p => p.Price.Currency == request.Currency); // Optional filtering by currency
        }

        // Fetch products from the database
        var products = await query.ToListAsync(cancellationToken);

        return products;
    }
}