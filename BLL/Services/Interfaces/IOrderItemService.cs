using BLL.DTO.Request;
using BLL.DTO.Response;

namespace BLL.Services.Interfaces;

public interface IOrderItemService
{
	Task<OrderItemResponseDTO> CreateAsync(OrderItemRequestDTO orderItem);
	Task UpdateAsync(int id, OrderItemRequestDTO orderItem);
	Task DeleteAsync(int id);
	Task<OrderItemResponseDTO> GetByIdAsync(int id);
	Task<int> GetProductCountById(int Id);
	Task<string> GetProductNameById(int Id);
}
