using BLL.Services.Implementations;
using BLL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using BLL.Validators;
using FluentValidation;

namespace BLL.Extensions;

public static class DIConfigurationBLL
{
	public static IServiceCollection ConfigureBLLServices(this IServiceCollection services)
	{
		return services.AddScoped<ICategoryService, CategoryService>()
			.AddScoped<IProductService, ProductService>();
	}

	public static IServiceCollection ConfigureBLLValidators(this IServiceCollection services)
	{
		return services.AddValidatorsFromAssemblyContaining<UserRequestDTOValidator>();
	}
}