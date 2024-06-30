using BLL.DTO.Request;
using BLL.DTO.Response;
using BLL.Exceptions;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using FluentValidation;
using Mapster;
using System.Net.WebSockets;

namespace BLL.Services.Implementations;

public class CategoryService : ICategoryService
{
	private readonly ICategoryRepository _categoryRepository;
	private readonly IValidator<CategoryRequestDTO> _validator;
    public CategoryService(ICategoryRepository categoryRepository, IValidator<CategoryRequestDTO> validator)
    {
        _categoryRepository = categoryRepository;
		_validator = validator;
    }
    public async Task<CategoryResponseDTO> CreateAsync(CategoryRequestDTO category)
	{
		var validationResult = await _validator.ValidateAsync(category);

		if (!validationResult.IsValid)
		{
			throw new Exceptions.ValidationException("Validation error");
		}

		var mappedCategory = category.Adapt<Category>();

		_categoryRepository.CreateAsync(mappedCategory);

		var response = mappedCategory.Adapt<CategoryResponseDTO>();
		return response;
	}

	public async Task DeleteAsync(int id)
	{
		var category = await _categoryRepository.GetByIdAsync(id);

		if (category == null)
		{
			throw new NotFoundException($"Category with id {id} not found");
		}

		_categoryRepository.DeleteAsync(category);
	}

	public async Task<IEnumerable<CategoryResponseDTO>> GetAllAsync()
	{
		var categories = await _categoryRepository.GetAllAsync();

		var mappedCategories = categories.Adapt<IEnumerable<CategoryResponseDTO>>();

		return mappedCategories;
	}

	public async Task<CategoryResponseDTO> GetByIdAsync(int id)
	{
		var category = await _categoryRepository.GetByIdAsync(id);

		if (category == null)
		{
			throw new NotFoundException($"Category with id {id} not found");
		}

		var mappedCategory = category.Adapt<CategoryResponseDTO>();
		return mappedCategory;
	}

	public async Task UpdateAsync(int id, CategoryRequestDTO category)
	{
		var validationResult = await _validator.ValidateAsync(category);

        if (!validationResult.IsValid)
        {
			throw new Exceptions.ValidationException("Validation error");
        }

		var categoryExist = await _categoryRepository.GetByIdAsync(id);

		if (categoryExist == null)
		{
			throw new NotFoundException($"Category with id {id} not found");
		}

		category.Adapt(categoryExist);

		_categoryRepository.UpdateAsync(categoryExist);
    }
}
