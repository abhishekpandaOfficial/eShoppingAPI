using MediatR;

namespace eShopping.API.Application.Features.Products.Commands;

public class UpdateProductCommand :IRequest<bool>
{
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; }

    public UpdateProductCommand(Guid productId, string name, string description, decimal amount, string currency)
    {
        ProductId = productId;
        Name = name;
        Description = description;
        Amount = amount;
        Currency = currency;
    }
}