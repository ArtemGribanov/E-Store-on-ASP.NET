namespace BLL.Exceptions.AlreadyExist;

public class UserAlreadyExistException : Exception
{
	public UserAlreadyExistException() : base("User with this email alerady exists") 
	{ }
}
