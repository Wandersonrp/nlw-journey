namespace TripPlanner.Application.Services.PasswordEncrypter;

public interface IPasswordEncrypter
{
    string Encrypt(string password);
}
