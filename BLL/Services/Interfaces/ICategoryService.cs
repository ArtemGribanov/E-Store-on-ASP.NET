using BLL.DTO.Request;
using BLL.DTO.Response;

namespace BLL.Services.Interfaces;

public interface ICategoryService
{
	Task<CategoryResponseDTO> CreateAsync(CategoryRequestDTO category);
	Task UpdateAsync(int id, CategoryRequestDTO category);
	Task DeleteAsync(int id);
	Task<CategoryResponseDTO> GetByIdAsync(int id);
	Task<IEnumerable<CategoryResponseDTO>> GetAllAsync();
}
