namespace BLL.Exceptions.BadRequest;

public class BadRequestException : Exception
{
	BadRequestException(string message) : base(message)
	{ }
}
