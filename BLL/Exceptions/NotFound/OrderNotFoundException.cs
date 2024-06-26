namespace BLL.Exceptions.NotFound;

public class OrderNotFoundException : Exception
{
	public OrderNotFoundException(int id) : base($"Order with id {id} doesn't exist")
	{ }
}
