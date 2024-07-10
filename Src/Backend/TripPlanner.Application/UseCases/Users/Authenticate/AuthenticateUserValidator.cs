using FluentValidation;
using TripPlanner.Communication.Requests.Users;

namespace TripPlanner.Application.UseCases.Users.Authenticate;

public class AuthenticateUserValidator : AbstractValidator<RequestAuthenticateUserJson>
{
    public AuthenticateUserValidator()
    {
        RuleFor(e => e.Email).EmailAddress().WithMessage("Invalid email");
        RuleFor(e => e.Password).MinimumLength(8).WithMessage("Password must have at least 8 characters");
        RuleFor(e => e.Password).NotEmpty().WithMessage("Password is required");
    }
}