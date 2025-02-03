using eShopping.API.Application.Features.DTOs;
using eShopping.API.Application.Features.Interfaces;
using eShopping.API.Domain.ValueObjects;
using eShopping.API.Infrastructure.Persistence.DbContext;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace eShopping.API.Application.Features.Products.Commands.Handlers;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand,bool>
{
    private readonly IProductService _productService;
    private readonly IValidator<ProductDTO> _productValidator;

    public UpdateProductHandler(IProductService productService, IValidator<ProductDTO> productValidator)
    {
        _productService = productService;
        _productValidator = productValidator;
        
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        // Validate product DTO
        var validationResult = await _productValidator.ValidateAsync(request.Product, cancellationToken);
        if (!validationResult.IsValid)
        {
            // Optionally, throw an exception or return false indicating failure
            return false;
        }

        try
        {
            // Attempt to update product
            await _productService.UpdateProductAsync(request.Product);
            return true;
        }
        catch (Exception ex)
        {
            // Handle any potential error during the update operation
            // Log the error, return false, or throw a custom exception
            return false;
        }
    }
}