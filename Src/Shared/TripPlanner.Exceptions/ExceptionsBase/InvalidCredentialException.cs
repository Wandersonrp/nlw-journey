namespace TripPlanner.Exceptions.ExceptionsBase;

public class InvalidCredentialException : TripPlannerException
{
    public InvalidCredentialException() : base("Invalid credential")
    {}
}