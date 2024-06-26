namespace BLL.Exceptions.AlreadyExist;

public class OrderAlreadyExistException : Exception
{
	OrderAlreadyExistException() : base("This order already exists")
	{ }
}
