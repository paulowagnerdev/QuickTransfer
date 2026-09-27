using System.Security.Cryptography;

namespace Application.Services.Token;

public class TokenMaker
{
    public static string CreateToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
    }
}