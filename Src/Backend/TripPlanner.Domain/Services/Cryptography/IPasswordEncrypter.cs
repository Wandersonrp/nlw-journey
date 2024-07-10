namespace TripPlanner.Domain.Services.Cryptography;

public interface IPasswordEncrypter
{
    string Encrypt(string password);   
}