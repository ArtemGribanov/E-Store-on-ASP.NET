using BLL.DTO.Request;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Store.Controllers;

[ApiController]
[Route("[Controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status409Conflict)]
	public async Task<IActionResult> CreateAsync(CategoryRequestDTO category)
    {
        var newCategory = await _categoryService.CreateAsync(category);

        return CreatedAtRoute("GetCategoryByIdAsync", new {id = newCategory.Id}, newCategory);
    }
    [HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public async Task<IActionResult> GetAllAsync()
    {
        var categories = await _categoryService.GetAllAsync();

        return Ok(categories);
    }
    [HttpGet("{id}", Name = "GetCategoryByIdAsync")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> GetByIdAsync(int id)
    {
        var category = await _categoryService.GetByIdAsync(id);

        return Ok(category);
    }
	[HttpDelete("{id}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> DeleteAsync(int id)
    {
        await _categoryService.DeleteAsync(id);

        return NoContent();
    }
	[HttpPut]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> UpdateAsync(int id, CategoryRequestDTO category)
    {
        await _categoryService.UpdateAsync(id, category);

        return NoContent();
    }
}
