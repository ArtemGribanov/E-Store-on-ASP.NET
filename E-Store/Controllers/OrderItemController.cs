using BLL.DTO.Request;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Store.Controllers;

[ApiController]
[Route("[Controller]")]
public class OrderItemController : ControllerBase
{
	private readonly IOrderItemService _orderItemService;

    public OrderItemController(IOrderItemService orderItemService)
    {
        _orderItemService = orderItemService;
    }

    [HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status409Conflict)]
	public async Task<IActionResult> CreateAsync(OrderItemRequestDTO orderItem)
    {
        var newOrderItem = await _orderItemService.CreateAsync(orderItem);

        return CreatedAtRoute("GetOrderItemById", newOrderItem);
    }

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<IActionResult> GetAllAsync()
    {
        var orderItems = await _orderItemService.GetAllAsync();

        return Ok(orderItems);
    }

    [HttpGet("{id}", Name = "GetOrderItemById")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> GetByIdAsync(int orderId, int productId)
    {
        var orderItem = await _orderItemService.GetByIdAsync(orderId, productId);

        return Ok(orderItem);
    }

    [HttpPut]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> UpdateAsync(int orderId, int productId, OrderItemRequestDTO orderItem)
    {
        await _orderItemService.UpdateAsync(orderId, productId, orderItem);

        return NoContent();
    }

    [HttpDelete]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> DeleteAsync(int orderId, int productId)
    {
        await _orderItemService.DeleteAsync(orderId, productId);

        return NoContent();
    }
}
