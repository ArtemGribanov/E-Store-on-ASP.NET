using BLL.DTO.Request;
using BLL.DTO.Response;

namespace BLL.Services.Interfaces;

public interface IOrderService
{
	Task<OrderResponseDTO> CreateAsync(OrderRequestDTO order);
	Task UpdateAsync(int id, OrderRequestDTO order);
	Task DeleteAsync(int id);
	Task<OrderResponseDTO> GetByIdAsync(int id);
	Task<IEnumerable<OrderResponseDTO>> GetByUserIdAsync(int id);
	Task<IEnumerable<OrderResponseDTO>> GetAllAsync();
}
