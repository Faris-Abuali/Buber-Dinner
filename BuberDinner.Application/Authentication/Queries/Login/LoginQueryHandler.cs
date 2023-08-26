using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace BuberDinner.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask; // This is just to make the compiler happy :)
        
        var user = _userRepository.GetUserByEmail(query.Email);
        
        // 1. Validate the user exists
        if (user is null)
        {
            // throw new Exception("User with given email does not exist.");
            return Errors.Authentication.InvalidCredentials;
        }

        // 2. Validate the password is correct
        if (user.Password != query.Password)
        {
            // throw new Exception("Invalid password.");
            // We can return a list of errors
            return new [] { Errors.Authentication.InvalidCredentials };
        }

        // 3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}