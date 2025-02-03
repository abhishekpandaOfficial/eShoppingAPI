using eShopping.API.Application.Features.DTOs;
using eShopping.API.Domain.Entities;
using MediatR;

namespace eShopping.API.Application.Features.Products.Queries;

public class GetProductsQuery:IRequest<IEnumerable<ProductDTO>>
{
   
}