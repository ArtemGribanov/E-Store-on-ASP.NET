namespace BLL.Exceptions.AlreadyExist;

public class OrderAlreadyExistException : AlreadyExistException
{
	OrderAlreadyExistException() : base("This order already exists")
	{ }
}
