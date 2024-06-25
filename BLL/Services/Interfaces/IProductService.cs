using BLL.DTO.Request;
using BLL.DTO.Response;

namespace BLL.Services.Interfaces;

public interface IProductService
{
	Task<ProductResponseDTO> CreateAsync(ProductRequestDTO product);
	Task UpdateAsync(int id, ProductRequestDTO product);
	Task DeleteAsync(int id);
	Task<ProductResponseDTO> GetByIdAsync(int id);
}
