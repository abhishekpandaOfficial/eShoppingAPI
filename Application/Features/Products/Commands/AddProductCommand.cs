using MediatR;

namespace eShopping.API.Application.Features.Products.Commands;

public class AddProductCommand :IRequest<Guid> // Return type is Guid (the Id of the created Product)
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}