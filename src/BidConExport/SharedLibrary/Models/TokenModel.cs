namespace SharedLibrary.Models;
public class TokenModel
{
    
    public static TokenModel Empty => new TokenModel();
    public string Token { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
    public override bool Equals(object? obj)
    {
        if (obj is TokenModel model)
        {
            return Token == model.Token;
        }
        else
        {
            return false;
        }
    }
    public override int GetHashCode()
    {
        return Token.GetHashCode();
    }
}
