using eShopping.API.Application.Features.DTOs;
using eShopping.API.Domain.Entities;
using MediatR;

namespace eShopping.API.Application.Features.Products.Queries;

public class GetProductByIdQuery : IRequest<ProductDTO>
{
    public Guid Id { get; set; }

    public GetProductByIdQuery(Guid id)
    {
        Id = id;
    }
}