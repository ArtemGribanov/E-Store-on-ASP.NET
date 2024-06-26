namespace BLL.Exceptions.ValidationException;

public class ValidationException : Exception
{
	public ValidationException(string message) : base(message) 
	{ }
}
