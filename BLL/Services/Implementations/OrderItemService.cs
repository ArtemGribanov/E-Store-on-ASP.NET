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
	private readonly IOrderRepository _orderRepository;
	private readonly IProductRepository _productRepository;
	private readonly IValidator<OrderItemRequestDTO> _validator;
	public OrderItemService(
		IOrderItemRepository orderItemRepository,
		IOrderRepository orderRepository,
		IProductRepository productRepository,
		IValidator<OrderItemRequestDTO> validator)
	{
		_orderItemRepository = orderItemRepository;
		_orderRepository = orderRepository;
		_productRepository = productRepository;
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

	public async Task DeleteAsync(int orderId, int productId)
	{
		var orderItem = await _orderItemRepository.GetByIdAsync(orderId, productId);

		if (orderItem == null)
		{
			// exception
		}

		_orderItemRepository.DeleteAsync(orderId, productId);
	}

	public async Task<OrderItemResponseDTO> GetByIdAsync(int orderId, int productId)
	{
		var order = await _orderRepository.GetByIdAsync(orderId);

		if ( order == null )
		{
			// exception
		}

		var product = await _productRepository.GetByIdAsync(productId);

		if ( product == null )
		{
			// exception
		}

		var orderItem = await _orderItemRepository.GetByIdAsync(orderId, productId);
		
		if (orderItem == null)
		{
			// exception
		}

		return orderItem.Adapt<OrderItemResponseDTO>();
	}

	public async Task<int> GetProductCountById(int orderId, int productId)
	{
		var order = await _orderRepository.GetByIdAsync(orderId);

		if (order == null)
		{
			// exception
		}

		var product = await _productRepository.GetByIdAsync(productId);

		if (product == null)
		{
			// exception
		}

		var orderItem = await _orderItemRepository.GetByIdAsync(orderId, productId);

		if (orderItem == null)
		{
			// exception
		}

		return orderItem.Count;
	}

	public async Task UpdateAsync(int orderId, int productId, OrderItemRequestDTO orderItem)
	{
		var validationResult = await _validator.ValidateAsync(orderItem);

		if (!validationResult.IsValid)
		{
			// exception
		}

		var orderItemExist = await _orderItemRepository.GetByIdAsync(orderId, productId);

		throw new NotImplementedException();
	}
}
