namespace TripPlanner.Exceptions.ExceptionsBase;
public class ErrorOnValidationException : TripPlannerException
{
    public IList<string> ErrorMessages { get; set; }

    public ErrorOnValidationException(IList<string> errorMessages)
    {
        ErrorMessages = errorMessages;
    }
}
