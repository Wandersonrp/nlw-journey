namespace TripPlanner.Exceptions.ExceptionsBase;

public class ResourceNotFoundException : TripPlannerException
{
    public ResourceNotFoundException(string identifier): base($"Resource not found: {identifier}")
    {
        
    }
}