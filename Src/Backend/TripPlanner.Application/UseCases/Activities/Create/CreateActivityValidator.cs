using FluentValidation;
using TripPlanner.Communication.Requests.Activities;
using TripPlanner.Exceptions;

namespace TripPlanner.Application.UseCases.Activities.Create;

public class CreateActivityValidator : AbstractValidator<RequestCreateActivityJson>
{
    public CreateActivityValidator()
    {
        RuleFor(x => x.Name).NotNull().WithMessage(ResourceErrorMessages.ACTIVITY_NAME_NULL);
        RuleFor(x => x.Description).NotNull().WithMessage(ResourceErrorMessages.ACTIVITY_DESCRIPTION_NULL);
        When(x => x.StartDate != default && x.EndDate != default, () =>
        {
            RuleFor(x => x.StartDate)
                .LessThan(x => x.EndDate)
                .WithMessage(ResourceErrorMessages.START_DATE_GREATER_THAN_END_DATE);

            RuleFor(x => x.EndDate)
                .GreaterThan(x => x.StartDate)
                .WithMessage(ResourceErrorMessages.END_DATE_LESS_THAN_START_DATE);
        });
    }
}
