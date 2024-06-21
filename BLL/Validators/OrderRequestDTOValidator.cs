using BLL.DTO.Request;
using FluentValidation;

namespace BLL.Validators;

public class OrderRequestDTOValidator : AbstractValidator<OrderRequestDTO>
{
	public OrderRequestDTOValidator()
	{
		RuleFor(order => order.UserId)
			.NotNull()
			.NotEmpty();
	}
}
