using eShopping.API.Domain.Entities;
using MediatR;

namespace eShopping.API.Application.Features.Products.Queries;

public class GetProductByIdQuery : IRequest<Product>
{
    public Guid Id { get; set; }

    public GetProductByIdQuery(Guid id)
    {
        Id = id;
    }
}