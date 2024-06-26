namespace BLL.Exceptions.AlreadyExist;

public class OrderItemAlreadyExistException : AlreadyExistException
{
	OrderItemAlreadyExistException() : base("This orderItem already exists")
	{ }
}
