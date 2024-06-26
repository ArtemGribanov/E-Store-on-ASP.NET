using BLL.DTO.Request;
using BLL.DTO.Response;
using BLL.Services.Interfaces;

namespace BLL.Services.Implementations;

public class UserService : IUserService
{
	public Task<UserResponseDTO> CreateAsync(UserRequestDTO user)
	{
		throw new NotImplementedException();
	}

	public Task DeleteAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task<UserResponseDTO> GetByIdAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Task UpdateAsync(int id, UserRequestDTO user)
	{
		throw new NotImplementedException();
	}
}
