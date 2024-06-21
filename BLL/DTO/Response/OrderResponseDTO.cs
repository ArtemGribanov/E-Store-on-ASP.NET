namespace BLL.DTO.Response;

public class OrderResponseDTO
{
	public int Id { get; set; }
	public int UserId { get; set; }
	public UserResponseDTO User { get; set; }
	public ICollection<OrderItemResponseDTO> OrderItems { get; set; }
}
