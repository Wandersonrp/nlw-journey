﻿using TripPlanner.Communication.Requests.Users;
using TripPlanner.Domain.Entities;
using TripPlanner.Domain.Repositories;
using TripPlanner.Domain.Services.Cryptography;
using TripPlanner.Exceptions.ExceptionsBase;

namespace TripPlanner.Application.UseCases.Users.Register;

public class RegisterUserUseCase : IRegisterUser
{    
    private readonly IUserRepository _userRepository;
    private readonly IPasswordEncrypter _passwordEncrypter;

    public RegisterUserUseCase(
        IUserRepository userRepository, 
        IPasswordEncrypter passwordEncrypter
    )
    {
        _userRepository = userRepository;
        _passwordEncrypter = passwordEncrypter;
    }

    public async Task Execute(RequestRegisterUserJson request)
    {
        await Validate(request);

        var hashedPassword = _passwordEncrypter.Encrypt(request.Password);

        var user = new User
        {
            Email = request.Email,
            Name = request.Name,
            Password = hashedPassword,            
        };

        await _userRepository.AddAsync(user);       
    }

    private async Task Validate(RequestRegisterUserJson request)
    {
        var validator = new RegisterUserValidator();
        
        var result = validator.Validate(request);

        var userExistsWithSameEmail = await _userRepository.ExistsWithSameEmail(request.Email);        
        
        if(userExistsWithSameEmail)
        {
            throw new ResourceAlreadyExistsException(request.Email);
        }

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);            
        }
    }
}
