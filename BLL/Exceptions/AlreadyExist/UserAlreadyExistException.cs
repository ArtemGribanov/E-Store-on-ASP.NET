namespace BLL.Exceptions.AlreadyExist;

public class UserAlreadyExistException : AlreadyExistException
{
	public UserAlreadyExistException() : base("User with this email alerady exists") 
	{ }
}
