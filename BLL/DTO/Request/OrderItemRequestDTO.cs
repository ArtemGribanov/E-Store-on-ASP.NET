namespace BLL.DTO.Request;

public class OrderItemRequestDTO
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Count { get; set; }
}
