using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace BuberDinner.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    
    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        
        var authResult = await _mediator.Send(command);
        
        return authResult.Match(
            result => Ok(_mapper.Map<AuthenticationResponse>(result)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        
        var authResult = await _mediator.Send(query);
        
        if (authResult.IsError &&
            authResult.FirstError == Domain.Common.Errors.Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description);
        }
        
        return authResult.Match(
            result => Ok(_mapper.Map<AuthenticationResponse>(result)),
            errors => Problem(errors));
    }
}