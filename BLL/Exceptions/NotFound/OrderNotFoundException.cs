namespace BLL.Exceptions.NotFound;

public class OrderNotFoundException : NotFoundException
{
	public OrderNotFoundException(int id) : base($"Order with id {id} doesn't exist")
	{ }
}
