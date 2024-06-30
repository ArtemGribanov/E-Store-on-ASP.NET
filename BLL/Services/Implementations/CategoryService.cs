using BLL.DTO.Request;
using BLL.DTO.Response;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using FluentValidation;

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
    public Task<CategoryResponseDTO> CreateAsync(CategoryRequestDTO category)
	{
		throw new NotImplementedException();
	}

	public Task DeleteAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<CategoryResponseDTO>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public Task<CategoryResponseDTO> GetByIdAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task UpdateAsync(int id, CategoryRequestDTO category)
	{
		throw new NotImplementedException();
	}
}
