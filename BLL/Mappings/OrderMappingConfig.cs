using BLL.DTO.Response;
using DAL.Entities;
using Mapster;

namespace BLL.Mappings;

public class OrderMappingConfig : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<OrderResponseDTO, Order>();
	}
}
