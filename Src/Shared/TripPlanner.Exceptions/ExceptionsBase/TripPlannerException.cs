namespace TripPlanner.Exceptions.ExceptionsBase;

public class TripPlannerException : SystemException
{
    public TripPlannerException(string message) : base(message)
    {        
    }

    public TripPlannerException() { }
    
}
