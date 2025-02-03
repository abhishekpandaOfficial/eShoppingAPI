using eShopping.API.Application.Features.DTOs;

namespace eShopping.API.Application.Features.Interfaces;

public interface IOrderService
{
    Task<IEnumerator<OrderDTO>> GetOrdersAsync();
    Task<OrderDTO> GetOrderAsync(Guid id);
    Task PlaceOrderAsync(OrderDTO order);
}