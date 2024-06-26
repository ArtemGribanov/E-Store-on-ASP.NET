using BLL.DTO.Request;
using BLL.DTO.Response;

namespace BLL.Services.Interfaces;

public interface IUserService
{
	Task<UserResponseDTO> CreateAsync(UserRequestDTO user);
	Task UpdateAsync(int id, UserRequestDTO user);
	Task DeleteAsync(int id);
	Task<UserResponseDTO> GetByIdAsync(int id);
}
