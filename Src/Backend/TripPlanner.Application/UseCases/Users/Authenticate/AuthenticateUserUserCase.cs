using TripPlanner.Application.Services.Auth.Jwt.Generator;
using TripPlanner.Application.Services.PasswordEncrypter;
using TripPlanner.Communication.Requests.Users;
using TripPlanner.Communication.Responses.Users;
using TripPlanner.Domain.Entities;
using TripPlanner.Domain.Repositories;
using TripPlanner.Exceptions.ExceptionsBase;

namespace TripPlanner.Application.UseCases.Users.Authenticate;

public class AuthenticateUserUserCase : IAuthenticateUser
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordEncrypter _passwordEncrypter;
    private readonly IAccessTokenGenerator _accessTokenGenerator;

    public AuthenticateUserUserCase(
        IUserRepository userRepository, 
        IPasswordEncrypter passwordEncrypter, 
        IAccessTokenGenerator accessTokenGenerator
    )
    {
        _userRepository = userRepository;
        _passwordEncrypter = passwordEncrypter;
        _accessTokenGenerator = accessTokenGenerator;
    }

    public async Task<ResponseAuthenticateUserJson> Execute(RequestAuthenticateUserJson request)
    {
        Validate(request);

        var hashedPassword = _passwordEncrypter.Encrypt(request.Password);
        
        var user = await _userRepository.GetByEmailAndPassword(request.Email, hashedPassword) ??
            throw new ResourceNotFoundException(request.Email);

        var accessToken = _accessTokenGenerator.GenerateToken(user);

        return new ResponseAuthenticateUserJson
        {
            AccessToken = accessToken,
            Name = user.Name,
        };
    }

    private void Validate(RequestAuthenticateUserJson request)
    {
        var validator = new AuthenticateUserValidator();
        
        var result = validator.Validate(request);        

        if(!result.IsValid) 
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }        
    }
}