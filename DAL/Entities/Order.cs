namespace DAL.Entities;
public class Order
{
	public int Id { get; set; }
	public int UserId { get; set; }
	public User User { get; set; }
	public ICollection<OrderItem> OrderItems { get; set; }
}
