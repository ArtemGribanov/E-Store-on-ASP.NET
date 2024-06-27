using BLL.DTO.Request;
using BLL.DTO.Response;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using FluentValidation;
using Mapster;

namespace BLL.Services.Implementations;

public class OrderItemService : IOrderItemService
{
	private readonly IOrderItemRepository _orderItemRepository;
	private readonly IValidator<OrderItemRequestDTO> _validator;
	public OrderItemService(IOrderItemRepository orderItemRepository, IValidator<OrderItemRequestDTO> validator)
	{
		_orderItemRepository = orderItemRepository;
		_validator = validator;
	}
	public async Task<OrderItemResponseDTO> CreateAsync(OrderItemRequestDTO orderItem)
	{
		var validationResult = await _validator.ValidateAsync(orderItem);
		if (!validationResult.IsValid)
		{
			// exception
		}

		var orderItemExist = await _orderItemRepository.FindAsync(item => 
		item.OrderId == orderItem.OrderId &&
		item.ProductId == orderItem.ProductId);

		if (orderItemExist.Any())
		{
			// exception
		}

		var mappedOrderItem = orderItem.Adapt<OrderItem>();

		_orderItemRepository.CreateAsync(mappedOrderItem);

		var response = mappedOrderItem.Adapt<OrderItemResponseDTO>();
		return response;
	}

	public async Task DeleteAsync(int id)
	{
		var orderItem = await _orderItemRepository.GetByIdAsync(id);

		if (orderItem == null)
		{
			// exception
		}

		_orderItemRepository.DeleteAsync(id);
	}

	public async Task<OrderItemResponseDTO> GetByIdAsync(int id)
	{
		var orderItem = await _orderItemRepository.GetByIdAsync(id);
		
		if (orderItem == null)
		{
			// exception
		}

		return orderItem.Adapt<OrderItemResponseDTO>();
	}

	public async Task<int> GetProductCountById(int id)
	{
		var orderItem = await _orderItemRepository.GetByIdAsync(id);

		if (orderItem == null)
		{
			// exception
		}

		return orderItem.Count;
	}

	public Task<string> GetProductNameById(int id)
	{
		//var orderItem = await _orderItemRepository.GetByIdAsync(id);

		//if (orderItem == null)
		//{
		//	// exception
		//}

		//var product = await _orderItemRepository.GetAllAsync().Result.Where(item => item.ProductId == id);

		//return orderItem.;
		throw new NotImplementedException();
	}

	public async Task UpdateAsync(int id, OrderItemRequestDTO orderItem)
	{
		var validationResult = await _validator.ValidateAsync(orderItem);

		if (!validationResult.IsValid)
		{
			// exception
		}

		var orderItemExist = await _orderItemRepository.GetByIdAsync

		throw new NotImplementedException();
	}
}
