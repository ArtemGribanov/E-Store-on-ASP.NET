namespace BLL.Exceptions.AlreadyExist;

public class OrderItemAlreadyExistException : Exception
{
	OrderItemAlreadyExistException() : base("This orderItem already exists")
	{ }
}
