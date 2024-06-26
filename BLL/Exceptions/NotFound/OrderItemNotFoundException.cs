namespace BLL.Exceptions.NotFound;

public class OrderItemNotFoundException : NotFoundException
{
	OrderItemNotFoundException(int id) : base($"OrderItem with id {id} doesn't exist")
	{ }
}
