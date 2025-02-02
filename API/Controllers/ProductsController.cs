using eShopping.API.Application.Features.Products.Commands;
using eShopping.API.Application.Features.Products.Queries;
using eShopping.API.Domain.Entities;
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
    
    // GET: api/products
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts([FromQuery] GetProductsQuery query)
    {
        var products = await _mediator.Send(query);
        return Ok(products);
    }
    
    // GET: api/products/{id}
    [HttpGet("{id:guid}")]
    public async Task<ActionResult> GetProductById(Guid id)
    {
        var query = new GetProductByIdQuery(id);
        var product = await _mediator.Send(query);

        return Ok(product);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
    {
        // Call MediatR to handle the AddProductCommand
        var productId = await _mediator.Send(command);

        // Return the created product ID in the response
        return CreatedAtAction(nameof(AddProduct), new { id = productId }, productId);
    }
    
    [HttpPut("{productId}")]
    public async Task<IActionResult> UpdateProduct(Guid productId, [FromBody] UpdateProductCommand command)
    {
        command.ProductId = productId;  // Set ProductId

        var result = await _mediator.Send(command);
        if (!result)
        {
            return NotFound("Product not found");
        }

        return Ok("Product updated successfully");
    }
    [HttpDelete("{productId}")]
    public async Task<IActionResult> DeleteProduct(Guid productId)
    {
        var result = await _mediator.Send(new DeleteProductCommand(productId));
        if (!result)
        {
            return NotFound("Product not found");
        }

        return Ok("Product deleted successfully");
    }
}