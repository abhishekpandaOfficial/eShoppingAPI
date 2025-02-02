using eShopping.API.Domain.Entities;
using MediatR;

namespace eShopping.API.Application.Features.Products.Queries;

public class GetProductsQuery:IRequest<List<Product>>
{
    // You can add query parameters here if you want filtering options, e.g., Name, Price, etc.
    public string Name { get; set; }
    public string Currency { get; set; }
}