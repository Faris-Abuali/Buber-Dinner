using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using BuberDinner.Api.Common.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BuberDinner.Api.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        if (errors.Count is 0)
        {
            return Problem();
        }
        
        if (errors.All(error => error.Type == ErrorType.Validation))
        {
            return ValidationProblem(errors);
        }
        
        // `HttpContext.Items` Gets or sets a key/value collection that can be used to share data within the scope of this request.
        HttpContext.Items.Add(HttpContextItemKeys.Errors, errors);
        
        return Problem(errors[0]);
    }

    protected IActionResult Problem(List<Error> errors, int? statusCode)
    {
        // `HttpContext.Items` Gets or sets a key/value collection that can be used to share data within the scope of this request.
        HttpContext.Items.Add(HttpContextItemKeys.Errors, errors);
        
        var firstError = errors[0];
        
        return Problem(statusCode: statusCode, title: firstError.Description);
    }
    
    private IActionResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode: statusCode, title: error.Description);
    }
    
    private IActionResult ValidationProblem(List<Error> errors)
    {
        var modelStateDictionary = new ModelStateDictionary();

        errors.ForEach(error => modelStateDictionary.AddModelError(
            error.Code,
            error.Description));

        return ValidationProblem(modelStateDictionary);
    }
}