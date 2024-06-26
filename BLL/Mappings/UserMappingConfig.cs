using BLL.DTO.Response;
using DAL.Entities;
using Mapster;

namespace BLL.Mappings;

public class UserMappingConfig : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		throw new NotImplementedException();
		config.NewConfig<User, UserResponseDTO>()
			.Map(dest => dest.Orders, src => src.Orders);
	}
}
