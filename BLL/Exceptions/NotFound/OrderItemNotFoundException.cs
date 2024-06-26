namespace BLL.Exceptions.NotFound;

public class OrderItemNotFoundException : Exception
{
	OrderItemNotFoundException(int id) : base($"OrderItem with id {id} doesn't exist")
	{ }
}
