using BLL.DTO.Request;
using FluentValidation;

namespace BLL.Validators;

public class ProductRequestDTOValidator : AbstractValidator<ProductRequestDTO>
{
	public ProductRequestDTOValidator()
	{
		RuleFor(product => product.Count)
			.NotNull()
			.NotEmpty()
			.Must(product => product >= 0);

		RuleFor(product => product.Name)
			.NotNull()
			.NotEmpty()
			.Must(product => product.All(Char.IsLetter));

		RuleFor(product => product.Description)
			.MaximumLength(500);

		RuleFor(product => product.Price > 0)
			.NotNull()
			.NotEmpty();

		RuleFor(product => product.CategoryId)
			.NotNull()
			.NotEmpty();
	}
}
