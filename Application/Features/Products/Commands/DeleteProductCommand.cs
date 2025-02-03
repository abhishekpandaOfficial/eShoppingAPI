using MediatR;

namespace eShopping.API.Application.Features.Products.Commands;

public class DeleteProductCommand:IRequest
{
    public Guid ProductId { get; set; }

    public DeleteProductCommand(Guid productId)
    {
        ProductId = productId;
    }
}