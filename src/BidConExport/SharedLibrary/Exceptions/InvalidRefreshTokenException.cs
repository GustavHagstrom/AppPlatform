namespace SharedLibrary.Exceptions;
public class InvalidRefreshTokenException : Exception
{
	public InvalidRefreshTokenException() : base("RefreshToken is invalid")
	{

	}

	public InvalidRefreshTokenException(string message) : base(message)
	{
	}
}
