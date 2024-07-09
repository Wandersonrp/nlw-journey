using FluentValidation;
using TripPlanner.Communication.Requests.Users;
using TripPlanner.Exceptions;

namespace TripPlanner.Application.UseCases.Users.Register;

public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(e => e.Name).NotEmpty().WithMessage(ResourceErrorMessages.USER_NAME_EMPTY);
        RuleFor(e => e.Name).NotNull().WithMessage(ResourceErrorMessages.USER_NAME_NULL);
        RuleFor(e => e.Email).EmailAddress().WithMessage(ResourceErrorMessages.USER_EMAIL_INVALID);
        RuleFor(e => e.Email).NotEmpty().WithMessage(ResourceErrorMessages.USER_EMAIL_EMPTY);
        RuleFor(e => e.Email).NotNull().WithMessage(ResourceErrorMessages.USER_EMAIL_NULL);
        RuleFor(e => e.Password).NotNull().WithMessage(ResourceErrorMessages.USER_PASSWORD_NULL);
        RuleFor(e => e.Password).MinimumLength(8).WithMessage(ResourceErrorMessages.USER_PASSWORD_MIN_LENGTH);

        RuleFor(e => e.ConfirmPassword).NotNull().WithMessage(ResourceErrorMessages.USER_CONFIRM_PASSWORD_NULL);

        RuleFor(e => e.ConfirmPassword).MinimumLength(8).WithMessage(ResourceErrorMessages.USER_CONFIRM_PASSWORD_MIN_LENGTH);

        RuleFor(e => e.ConfirmPassword).Equal(e => e.Password).WithMessage(ResourceErrorMessages.USER_CONFIRM_PASSWORD_NOT_EQUAL);
    }
}
