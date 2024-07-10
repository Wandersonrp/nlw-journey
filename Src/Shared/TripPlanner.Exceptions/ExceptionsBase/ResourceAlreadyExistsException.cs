namespace TripPlanner.Exceptions.ExceptionsBase;

public class ResourceAlreadyExistsException : TripPlannerException
{    
    public ResourceAlreadyExistsException(string identifier) : base($"{ResourceErrorMessages.RESOURCE_ALREADY_EXISTS}{identifier}")
    {        
    }
}
