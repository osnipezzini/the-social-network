using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;

namespace TSN.Identity.Models;

public class AuthorizationOptions
{
    public AuthorizationOptions(KeycloakProtectionClientOptions options)
    {
    }

    public static implicit operator KeycloakProtectionClientOptions(AuthorizationOptions options) => new KeycloakProtectionClientOptions { };
    public static explicit operator AuthorizationOptions(KeycloakProtectionClientOptions options) => new AuthorizationOptions(options);
}
