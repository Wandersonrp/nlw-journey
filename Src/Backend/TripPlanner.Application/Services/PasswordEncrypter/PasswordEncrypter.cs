using System.Security.Cryptography;
using System.Text;

namespace TripPlanner.Application.Services.PasswordEncrypter;

public class PasswordEncrypter : IPasswordEncrypter
{
    private readonly string _salt;

    public PasswordEncrypter(string salt)
    {
        _salt = salt;
    }

    public string Encrypt(string password)
    {
        var passwordWithSalt = string.Concat(password, _salt);

        var bytes = Encoding.UTF8.GetBytes(passwordWithSalt);

        var hashBytes = SHA256.HashData(bytes);

        return StringBytes(hashBytes);        
    }

    private static string StringBytes(byte[] bytes)
    {
        var sb = new StringBuilder();

        foreach(byte b in bytes)
        {
            var hex = b.ToString("x2");

            sb.Append(hex);
        }

        return sb.ToString();
    }
}
