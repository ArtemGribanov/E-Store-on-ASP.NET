using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Exceptions.AlreadyExist;

public class ProductAlreadyExistsException : AlreadyExistException
{
	public ProductAlreadyExistsException() : base("This product already exists")
	{ }
}
