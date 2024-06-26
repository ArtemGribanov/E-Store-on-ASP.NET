using BLL.DTO.Request;
using BLL.DTO.Response;
using BLL.Services.Interfaces;

namespace BLL.Services.Implementations;

public class OrderItemService : IOrderItemService
{
	public Task<OrderItemResponseDTO> CreateAsync(OrderItemRequestDTO orderItem)
	{
		throw new NotImplementedException();
	}

	public Task DeleteAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task<OrderItemResponseDTO> GetByIdAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task<int> GetProductCountById(int Id)
	{
		throw new NotImplementedException();
	}

	public Task<string> GetProductNameById(int Id)
	{
		throw new NotImplementedException();
	}

	public Task UpdateAsync(int id, OrderItemRequestDTO orderItem)
	{
		throw new NotImplementedException();
	}
}
