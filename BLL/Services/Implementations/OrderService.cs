using BLL.DTO.Request;
using BLL.DTO.Response;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using FluentValidation;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.Implementations;

public class OrderService : IOrderService
{
	private readonly IOrderRepository _orderRepository;
	private readonly IUserRepository _userRepository;
	private readonly IValidator<OrderRequestDTO> _validator;
	public OrderService(
		IOrderRepository orderRepository,
		IUserRepository userRepository,
		IValidator<OrderRequestDTO> validator)
	{
		_orderRepository = orderRepository;
		_userRepository = userRepository;
		_validator = validator;
	}
	public async Task<OrderResponseDTO> CreateAsync(OrderRequestDTO order)
	{
		var validationResult = await _validator.ValidateAsync(order);

		if (!validationResult.IsValid) 
		{
			//exception validation error
		}

		var user = await _userRepository.GetByIdAsync(order.UserId);

		if (user == null)
		{
			//exception user doesnt exist
		}

		var mappedOrder = order.Adapt<Order>();

		_orderRepository.CreateAsync(mappedOrder);

		var response = mappedOrder.Adapt<OrderResponseDTO>();
		return response;
	}

	public async Task DeleteAsync(int id)
	{
		var order = await _orderRepository.GetByIdAsync(id);

		if (order == null)
		{
			//exception order doesnt exist
		}

		//_orderRepository.DeleteAsync(order);
	}

	public async Task<IEnumerable<OrderResponseDTO>> GetAllAsync()
	{
		var orders = await _orderRepository.GetAllAsync();
		var mappedOrders = orders.Adapt<IEnumerable<OrderResponseDTO>>();

		return mappedOrders;
	}

	public async Task<OrderResponseDTO> GetByIdAsync(int id)
	{
		var order = await _orderRepository.GetByIdAsync(id);

		if (order == null)
		{
			//exception order doesnt exist
		}

		return order.Adapt<OrderResponseDTO>();
	}

	public async Task<IEnumerable<OrderResponseDTO>> GetByUserIdAsync(int id)
	{
		var user = await _userRepository.GetByIdAsync(id);

		if(user == null)
		{
			//exception user doesnt exist
		}

		var orders = await _orderRepository
			.GetAllAsync()
			.Result
			.Where(order => order.Id == id)
			.AsQueryable()
			.ToListAsync();

		return orders.Adapt<IEnumerable<OrderResponseDTO>>();
	}

	public async Task UpdateAsync(int id, OrderRequestDTO order)
	{
		var validationResult = await _validator.ValidateAsync(order);

		if (validationResult.IsValid)
		{
			// exception validation error
		}

		var orderExist = await _orderRepository.GetByIdAsync(id);

		if (orderExist == null)
		{
			// exception order doesnt exist
		}

		order.Adapt(orderExist);

		_orderRepository.UpdateAsync(orderExist);

		//_orderRepository.SaveChangesAsync();
		//throw new NotImplementedException();
	}
}
