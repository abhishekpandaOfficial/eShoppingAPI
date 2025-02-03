using eShopping.API.Application.Features.DTOs;

namespace eShopping.API.Application.Features.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
    Task<ProductDTO> GetProductByIdAsync(Guid productId);
    Task<Guid> AddProductAsync(ProductDTO product);
    Task UpdateProductAsync(ProductDTO product);
    Task DeleteProductAsync(Guid productId);
    Task<bool> ProductExistsAsync(Guid productId);
}