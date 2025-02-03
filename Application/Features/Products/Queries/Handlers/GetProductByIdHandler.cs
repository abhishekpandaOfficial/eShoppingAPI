using eShopping.API.Application.Features.DTOs;
using eShopping.API.Domain.Entities;
using eShopping.API.Infrastructure.Persistence.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eShopping.API.Application.Features.Products.Queries.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDTO>
    {
        private readonly ApplicationDbContext _context;

        public GetProductByIdHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            // Retrieve the product from the database by Id
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (product == null)
            {
                // Throw exception if the product is not found
                throw new KeyNotFoundException($"Product with Id {request.Id} not found.");
            }

            // Manually map the Product entity to ProductDTO
            var productDto = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                // Add other properties that you need from the Product entity
                Description = product.Description,
                // You can map more properties here depending on your ProductDTO
            };

            return productDto;
        }
    }
}