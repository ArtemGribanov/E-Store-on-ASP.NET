namespace BLL.Exceptions.NotFound;

public class ProductNotFoundException : NotFoundException
{
	public ProductNotFoundException(int id) : base($"Product with id {id} doesn't exist")
	{ }
}
