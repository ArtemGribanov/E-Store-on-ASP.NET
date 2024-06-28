using BLL.DTO.Request;
using BLL.DTO.Response;

namespace BLL.Services.Interfaces;

public interface IOrderItemService
{
	Task<OrderItemResponseDTO> CreateAsync(OrderItemRequestDTO orderItem);
	Task UpdateAsync(int orderId, int productId,  OrderItemRequestDTO orderItem);
	Task DeleteAsync(int orderId, int productId);
	Task<OrderItemResponseDTO> GetByIdAsync(int orderId, int productId);
	Task<int> GetProductCountById(int orderId, int productId);
}
