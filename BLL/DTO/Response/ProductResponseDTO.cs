namespace BLL.DTO.Response;

public class ProductResponseDTO
{
	public int Id { get; set; }
	public int Count { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public decimal Price { get; set; }
	public int CategoryId { get; set; }
	public CategoryResponseDTO Category { get; set; }
	public ICollection<OrderItemResponseDTO> OrderItems { get; set; }
}
