namespace BLL.Exceptions;

public class BadRequestException : Exception
{
    BadRequestException(string message) : base(message)
    { }
}
