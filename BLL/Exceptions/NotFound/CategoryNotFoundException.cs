namespace BLL.Exceptions.NotFound;

public class CategoryNotFoundException : NotFoundException
{
	public CategoryNotFoundException(int id) : base($"Category with id {id} doesn't exist")
	{ }
}
