using BLL.DTO.Request;
using FluentValidation;

namespace BLL.Validators;

public class UserRequestDTOValidator : AbstractValidator<UserRequestDTO>
{
	public UserRequestDTOValidator()
	{
		RuleFor(user => user.Name)
			.NotNull()
			.NotEmpty()
			.Must(user => user.All(Char.IsLetter));

		RuleFor(user => user.Surname)
			.NotNull()
			.NotEmpty()
			.Must(user => user.All(Char.IsLetter));

		RuleFor(user => user.Email)
			.NotNull()
			.NotEmpty()
			.EmailAddress();

		RuleFor(user => user.Password)
			.NotNull()
			.NotEmpty();

		RuleFor(user => user.Sex)
			.Must(IsSexValid);
	}

	private bool IsSexValid(string sex)
	{
		if (sex == "male" || sex == "female")
			return true;
		else
			return false;
	}
}
