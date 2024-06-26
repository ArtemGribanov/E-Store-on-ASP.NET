namespace BLL.Exceptions.AlreadyExist;

public class CategoryAlreadyExistException : AlreadyExistException
{
	CategoryAlreadyExistException() : base("This category already exists")
	{ }
}
