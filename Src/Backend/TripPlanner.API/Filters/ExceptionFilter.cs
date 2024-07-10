using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using TripPlanner.Communication.Responses;
using TripPlanner.Exceptions;
using TripPlanner.Exceptions.ExceptionsBase;

namespace TripPlanner.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if(context.Exception is TripPlannerException)
        {
            HandleProjectException(context);
        } 
        else
        {
            ThrowUnknownException(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        if(context.Exception is ErrorOnValidationException)
        {
            var exception = context.Exception as ErrorOnValidationException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception!.ErrorMessages));
        }
        else if(context.Exception is ResourceAlreadyExistsException)
        {
            var exception = context.Exception as ResourceAlreadyExistsException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
            context.Result = new ConflictObjectResult(new ResponseErrorJson(exception!.Message));
        }
        else if(context.Exception is ResourceNotFoundException) 
        {
            var exception = context.Exception as ResourceNotFoundException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            context.Result = new NotFoundObjectResult(new ResponseErrorJson(exception!.Message));
        }
        else if(context.Exception is InvalidCredentialException) 
        {
            var exception = context.Exception as InvalidCredentialException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.Result = new NotFoundObjectResult(new ResponseErrorJson(exception!.Message));
        }
    }

    private void ThrowUnknownException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorJson(ResourceErrorMessages.UNKNOWN_ERROR));
    }
}
