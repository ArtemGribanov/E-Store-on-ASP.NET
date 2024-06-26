namespace BLL.Exceptions.NotFound;

public class UserNotFoundException : Exception
{
	public UserNotFoundException(int id) : base($"User with id {id} doesn't exist")
	{ }
}
