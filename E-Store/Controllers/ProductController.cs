using BLL.DTO.Request;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Store.Controllers;

[ApiController]
[Route("[Controller]")]
public class ProductController : ControllerBase
{
	IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status409Conflict)]
	public async Task<IActionResult> CreateAsync(ProductRequestDTO product)
	{
		var newProduct = await _productService.CreateAsync(product);

		return CreatedAtRoute("GetProductOrderById", new { id = newProduct.Id }, newProduct);
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<IActionResult> GetAllAsync()
	{
		var products = await _productService.GetAllAsync();

		return Ok(products);
	}
	[HttpGet("{id}", Name = "GetProductOrderById")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> GetByIdAsync(int id)
	{
		var product = await _productService.GetByIdAsync(id);

		return Ok(product);
	}
	[HttpPut]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> UpdateAsync(int id, ProductRequestDTO product)
	{
		await _productService.UpdateAsync(id, product);

		return NoContent();
	}
	[HttpDelete("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> DeleteAsync(int id)
	{
		await _productService.DeleteAsync(id);

		return NoContent();
	}
}
