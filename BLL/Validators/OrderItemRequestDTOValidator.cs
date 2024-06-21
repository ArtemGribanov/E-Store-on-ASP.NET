using BLL.DTO.Request;
using FluentValidation;

namespace BLL.Validators;

public class OrderItemRequestDTOValidator : AbstractValidator<OrderItemRequestDTO>
{
	public OrderItemRequestDTOValidator()
	{
		RuleFor(orderItem => orderItem.OrderId)
			.NotEmpty()
			.NotNull();

		RuleFor(orderItem => orderItem.ProductId)
			.NotEmpty()
			.NotNull();

		RuleFor(orderItem => orderItem.Count)
			.NotEmpty()
			.NotNull()
			.Must(orderItem => orderItem > 0);
	}
}
