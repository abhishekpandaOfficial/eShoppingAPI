using eShopping.API.Application.Features.DTOs;
using eShopping.API.Application.Features.Interfaces;
using eShopping.API.Domain.Entities;
using eShopping.API.Infrastructure.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;

namespace eShopping.API.Infrastructure.Persistence.Services;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;

    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }
// Method to get all products
    public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
    {
        var products = await _context.Products
            .Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description
                // Add other properties as needed
            })
            .ToListAsync();

        return products;
    }
    
    // Method to get a product by its ID
    public async Task<ProductDTO> GetProductByIdAsync(Guid productId)
    {
        var product = await _context.Products
            .Where(p => p.Id == productId)
            .Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description
                // Add other properties as needed
            })
            .FirstOrDefaultAsync();

        return product ?? throw new KeyNotFoundException($"Product with Id {productId} not found.");
    }
    
    // Method to add a new product
    public async Task<Guid> AddProductAsync(ProductDTO productDto)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(), // Assuming you want to generate the ID server-side
            Name = productDto.Name,
            Price = productDto.Price,
            Description = productDto.Description
            // Map other properties here
        };

        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product.Id;
    }
    
    // Method to update an existing product
    public async Task UpdateProductAsync(ProductDTO productDto)
    {
        var product = await _context.Products.FindAsync(productDto.Id);

        if (product == null)
        {
            throw new KeyNotFoundException($"Product with Id {productDto.Id} not found.");
        }

        // Update the product with the new data from ProductDTO
        product.Name = productDto.Name;
        product.Price = productDto.Price;
        product.Description = productDto.Description;
        // Update other properties as needed

        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    // Method to delete a product by ID
    public async Task DeleteProductAsync(Guid productId)
    {
        var product = await _context.Products.FindAsync(productId);

        if (product == null)
        {
            throw new KeyNotFoundException($"Product with Id {productId} not found.");
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
    
    // Method to check if a product exists by its ID
    public async Task<bool> ProductExistsAsync(Guid productId)
    {
        return await _context.Products.AnyAsync(p => p.Id == productId);
    }
}