using Keycloak.AuthServices.Authentication;

namespace TSN.Identity.Models;

public class AuthenticationOptions
{
    public AuthenticationOptions(KeycloakAuthenticationOptions options)
    {
    }

    public static implicit operator KeycloakAuthenticationOptions(AuthenticationOptions options) => new KeycloakAuthenticationOptions { };
    public static explicit operator AuthenticationOptions(KeycloakAuthenticationOptions options) => new AuthenticationOptions(options);
}
