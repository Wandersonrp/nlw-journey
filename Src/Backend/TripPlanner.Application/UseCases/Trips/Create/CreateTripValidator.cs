using FluentValidation;
using TripPlanner.Communication.Requests.Trips;
using TripPlanner.Exceptions;

namespace TripPlanner.Application.UseCases.Trips.Create;

public class CreateTripValidator : AbstractValidator<RequestCreateTripJson>
{
    public CreateTripValidator()
    {
        RuleFor(x => x.Origin)
            .NotNull()
            .WithMessage(ResourceErrorMessages.ORIGIN_NULL);

        RuleFor(x => x.Destination)
            .NotNull()
            .WithMessage(ResourceErrorMessages.DESTINATION_NULL);

        RuleFor(x => x.StartDate)
            .NotNull()
            .WithMessage(ResourceErrorMessages.START_DATE_NULL);

        RuleFor(x => x.StartDate)
            .NotNull()
            .WithMessage(ResourceErrorMessages.END_DATE_NULL);

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
