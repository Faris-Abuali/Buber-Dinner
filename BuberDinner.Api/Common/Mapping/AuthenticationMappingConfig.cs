using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using Mapster;

namespace BuberDinner.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();

        config.NewConfig<LoginRequest, LoginQuery>();

        // In the above 2 mappings, even though the property names are the same, we just want to be explicit of all Authentication mapping we do in the project.

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            // .Map(dest => dest.Token, src => src.Token) // This is not needed because the property names are the same.
            .Map(dest => dest, src => src.User);
    }
}