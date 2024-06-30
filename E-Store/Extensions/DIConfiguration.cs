using BLL.Extensions;
using DAL.Contexts;
using DAL.Extensions;
using Microsoft.EntityFrameworkCore;

namespace E_Store.Extensions;

public static class DIConfiguration
{
	public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
	{
		builder.Services.AddDbContext<EShopContext>(options =>
		{
			options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
		})
		.ConfigureDALRepositories()
		.ConfigureBLLServices()
		.ConfigureBLLValidators();

		return builder;
	}
}
