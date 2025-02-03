using eShopping.API.Application.Features.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace eShopping.API.Application.Features.Products.Commands.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductService _productService;

        public DeleteProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            // Check if the product exists in the database
            var productExists = await _productService.ProductExistsAsync(request.ProductId);

            if (!productExists)
            {
                // If product doesn't exist, throw an exception
                throw new KeyNotFoundException($"Product with Id {request.ProductId} not found.");
            }

            // Proceed with deletion if the product exists
            await _productService.DeleteProductAsync(request.ProductId);
            
            // Return Unit.Value to indicate success
            return Unit.Value;
        }
    }
}