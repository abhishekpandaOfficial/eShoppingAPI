using eShopping.API.Application.Features.Products.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eShopping.API.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController :ControllerBase
{
    private readonly IMediator _mediator;
    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
    {
        // Call MediatR to handle the AddProductCommand
        var productId = await _mediator.Send(command);

        // Return the created product ID in the response
        return CreatedAtAction(nameof(AddProduct), new { id = productId }, productId);
    }
}