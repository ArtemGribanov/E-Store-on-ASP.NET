using BLL.DTO.Request;
using FluentValidation;

namespace BLL.Validators;

public class CategoryRequestDTOValidator : AbstractValidator<CategoryRequestDTO>
{
	public CategoryRequestDTOValidator()
	{
		RuleFor(category => category.Name)
			.NotEmpty()
			.NotNull()
			.MaximumLength(150);
	}
}
