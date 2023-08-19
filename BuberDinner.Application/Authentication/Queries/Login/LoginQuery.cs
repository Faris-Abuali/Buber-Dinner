using BuberDinner.Application.Authentication.Common;
using MediatR;
using ErrorOr;

namespace BuberDinner.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;