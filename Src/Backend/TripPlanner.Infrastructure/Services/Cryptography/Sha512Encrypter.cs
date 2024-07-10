using System.Security.Cryptography;
using System.Text;
using TripPlanner.Domain.Services.Cryptography;

namespace TripPlanner.Infrastructure.Services.Cryptography;

public class Sha512Encrypter : IPasswordEncrypter
{
    private readonly string _salt;

    public Sha512Encrypter(string salt)
    {
        _salt = salt;
    }

    public string Encrypt(string password)
    {
        var passwordWithSalt = string.Concat(password, _salt);

        var bytes = Encoding.UTF8.GetBytes(passwordWithSalt);

        var hashBytes = SHA512.HashData(bytes);

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