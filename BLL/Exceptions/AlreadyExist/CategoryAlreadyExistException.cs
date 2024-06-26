namespace BLL.Exceptions.AlreadyExist;

public class CategoryAlreadyExistException : Exception
{
	CategoryAlreadyExistException() : base("This category already exists")
	{ }
}
