using eShopping.API.Application.Features.DTOs;
using eShopping.API.Application.Features.Interfaces;
using eShopping.API.Domain.Entities;
using eShopping.API.Infrastructure.Persistence.DbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eShopping.API.Application.Features.Products.Queries.Handlers;

public class GetProductsHandler: IRequestHandler<GetProductsQuery, IEnumerable<ProductDTO>>
{
   private readonly IProductService _productService;

    public GetProductsHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IEnumerable<ProductDTO>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await _productService.GetAllProductsAsync();
    }
}