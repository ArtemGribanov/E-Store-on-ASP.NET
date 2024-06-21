namespace BLL.DTO.Response;

public class CategoryResponseDTO
{
	public int Id { get; set; }
	public string Name { get; set; }
	public ICollection<ProductResponseDTO> Products { get; set; }
}
