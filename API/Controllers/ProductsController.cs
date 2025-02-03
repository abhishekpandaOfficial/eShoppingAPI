using eShopping.API.Application.Features.DTOs;
using eShopping.API.Application.Features.Products.Commands;
using eShopping.API.Application.Features.Products.Queries;
using eShopping.API.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eShopping.API.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    // GET: api/products
    [HttpGet]
    public async Task<ActionResult<List<ProductDTO>>> GetProducts()
    {
        var query = new GetProductsQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    
    // GET: api/products/{id}
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProductDTO>> GetProductById(Guid id)
    {
        var query = new GetProductByIdQuery(id); // Pass the id to the constructor
        var result = await _mediator.Send(query);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    
    // POST: api/products
    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
    {
        var productId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetProductById), new { id = productId }, productId);
    }
    
    // PUT: api/product/update
    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] ProductDTO productDto)
    {
        if (productDto == null)
        {
            return BadRequest("Product data is required.");
        }

        // Create UpdateProductCommand with the provided DTO
        var command = new UpdateProductCommand(productDto);

        // Send the command to MediatR for processing by the handler
        bool result = await _mediator.Send(command);

        // Return appropriate response based on the result
        if (result)
        {
            return NoContent(); // 204 No Content (successful update)
        }
        else
        {
            return StatusCode(500, "An error occurred while updating the product.");
        }
    }
    // DELETE: api/products/{productId}
    [HttpDelete("{productId:guid}")]
    public async Task<IActionResult> DeleteProduct(Guid productId)
    {
        try
        {
            // Sending the DeleteProductCommand to the mediator
            await _mediator.Send(new DeleteProductCommand(productId));

            // If no exception is thrown, it means the product was deleted successfully
            return Ok("Product deleted successfully");
        }
        catch (KeyNotFoundException)
        {
            // If product is not found, return NotFound with a message
            return NotFound("Product not found");
        }
        catch (Exception ex)
        {
            // Log the exception if necessary and return a generic error response
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

}