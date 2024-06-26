using BLL.DTO.Request;
using BLL.DTO.Response;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using FluentValidation;

namespace BLL.Services.Implementations;

public class OrderService : IOrderService
{
	private readonly IOrderRepository _orderRepository;
	private readonly IValidator<OrderRequestDTO> _validator;
	public async Task<OrderResponseDTO> CreateAsync(OrderRequestDTO order)
	{
		var validationResult = await _validator.ValidateAsync(order);

		if (!validationResult.IsValid) 
		{
			//exception
		}

		throw new NotImplementedException();
	}

	public Task DeleteAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<OrderResponseDTO>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public Task<OrderResponseDTO> GetByIdAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<OrderResponseDTO>> GetByUserIdAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task UpdateAsync(int id, OrderRequestDTO order)
	{
		throw new NotImplementedException();
	}
}
