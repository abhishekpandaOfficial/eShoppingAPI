namespace eShopping.API.Application.Features.DTOs;

public class OrderDTO
{
    public Guid OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public List<ProductDTO> Products { get; set; }
    public decimal TotalAmount { get; set; }
}