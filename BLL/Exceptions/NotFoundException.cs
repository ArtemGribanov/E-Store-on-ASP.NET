namespace BLL.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    { }
    public NotFoundException(string entityName, int id) : base($"{entityName} with id {id} doesn't exist")
    { }
}
