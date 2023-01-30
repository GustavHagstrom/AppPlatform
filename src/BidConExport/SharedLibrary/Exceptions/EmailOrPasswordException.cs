namespace SharedLibrary.Exceptions;
public class EmailOrPasswordException : Exception
{
	public EmailOrPasswordException() : base("Email or password is invalid or doesn't exist")
	{
		
	}

	public EmailOrPasswordException(string message) : base(message)
	{
	}
}
