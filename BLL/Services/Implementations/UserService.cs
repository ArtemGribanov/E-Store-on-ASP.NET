using BLL.DTO.Request;
using BLL.DTO.Response;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using FluentValidation;
using Mapster;

namespace BLL.Services.Implementations;

public class UserService : IUserService
{
	private readonly IUserRepository _userRepository;
	private readonly IValidator<UserRequestDTO> _validator;
	public UserService(IUserRepository userRepository, IValidator<UserRequestDTO> validator)
	{
		_userRepository = userRepository;
		_validator = validator;
	}

	public async Task<UserResponseDTO> CreateAsync(UserRequestDTO user)
	{
		var validationResult = await _validator.ValidateAsync(user);

		if (!validationResult.IsValid)
		{
			// exception
		}

		var userExist = await _userRepository.FindAsync(usr => usr.Email == user.Email);

		if (userExist.Any())
		{
			// exception
		}

		var mappedUser = user.Adapt<User>();
		_userRepository.CreateAsync(mappedUser);

		var response = mappedUser.Adapt<UserResponseDTO>();
		return response;
	}

	public async Task DeleteAsync(int id)
	{
		var user = await _userRepository.GetByIdAsync(id);

		if (user == null)
		{
			// exception
		}

		_userRepository.DeleteAsync(id);
	}

	public async Task<UserResponseDTO> GetByIdAsync(int id)
	{
		var user = await _userRepository.GetByIdAsync(id);

		if (user == null)
		{
			// exception
		}

		return user.Adapt<UserResponseDTO>();
	}

	public async Task UpdateAsync(int id, UserRequestDTO user)
	{
		var validationResult = await _validator.ValidateAsync(user);

		if (!validationResult.IsValid)
		{
			//exception
		}

		var userExist = await _userRepository.GetByIdAsync(id);
		
		if ( userExist == null)
		{
			// exception
		}

		user.Adapt(userExist);

		_userRepository.UpdateAsync(userExist);
	}
}
