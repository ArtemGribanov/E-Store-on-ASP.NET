using BLL.Services.Implementations;
using BLL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using BLL.Validators;

namespace BLL.Extensions;

public static class BLLDIConfiguration
{
	public static IServiceCollection ConfigureBLLServices(this IServiceCollection services)
	{
		return services.AddScoped<IOrderItemService, OrderItemService>()
			.AddScoped<IOrderService, OrderService>()
			.AddScoped<IUserService, UserService>();
	}

	public static IServiceCollection ConfigureBLLValidators(this IServiceCollection services)
	{
		return services.AddValidatorsFromAssemblyContaining<UserRequestDTOValidator>();
	}
}
