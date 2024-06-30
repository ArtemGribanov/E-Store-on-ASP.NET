using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Extensions;

public static class DIConfigurationDAL
{
	public static IServiceCollection ConfigureDALRepositories(this IServiceCollection services)
	{
		return services.AddScoped<ICategoryRepository, CategoryRepository>()
			.AddScoped<IOrderItemRepository, OrderItemRepository>()
			.AddScoped<IOrderRepository, OrderRepository>()
			.AddScoped<IProductRepository, ProductRepository>()
			.AddScoped<IUserRepository, UserRepository>();
	}
}