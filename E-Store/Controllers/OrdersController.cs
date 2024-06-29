using BLL.DTO.Request;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Store.Controllers;

[ApiController]
[Route("[Controller]")]
public class OrdersController : ControllerBase
{
	private readonly IOrderService _orderService;
	private readonly IOrderItemService _orderItemService;

	public OrdersController(IOrderService orderService, IOrderItemService orderItemService)
	{
		_orderService = orderService;
		_orderItemService = orderItemService;
	}


	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status409Conflict)]
	public async Task<IActionResult> CreateAsync(OrderRequestDTO order)
	{
		var newOrder = await _orderService.CreateAsync(order);

		return CreatedAtRoute("GetOrderById", new { id = newOrder.Id }, newOrder);
	}


	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<IActionResult> GetAllAsync()
	{
		var orders = await _orderService.GetAllAsync();

		return Ok(orders);
	}


	[HttpGet("{id}", Name = "GetOrderById")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> GetByIdAsync(int id)
	{
		var order = await _orderService.GetByIdAsync(id);
		return Ok(order);
	}


	[HttpPut]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> UpdateAsync(int id, OrderRequestDTO order)
	{
		await _orderService.UpdateAsync(id, order);

		return NoContent();
	}


	[HttpDelete("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Delete(int id)
	{
		await _orderService.DeleteAsync(id);

		return NoContent();
	}

	[HttpPost("{orderId}/items/{orderItemId}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> AddItemToOrder(int orderId, int productId, int productCount = 1)
	{
		await _orderItemService.CreateAsync(new OrderItemRequestDTO 
		{
			OrderId = orderId, 
			ProductId = productId, 
			Count = productCount 
		});

		return NoContent();
	}
}
