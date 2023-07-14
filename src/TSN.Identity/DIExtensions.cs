using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using TSN.Identity.Models;

namespace TSN.Identity;

public static class DIExtensions
{
    /// <summary>
    /// Configura a autenticação de usuário.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static WebApplicationBuilder ConfigureAuthentication(this WebApplicationBuilder builder, Action<AuthenticationOptions>? options = null)
    {
        if (builder == null) throw new ArgumentNullException(nameof(builder));
        builder.Services.ConfigureAuthentication(options);
        return builder;
    }
    /// <summary>
    /// Configura a autenticação de usuário.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, Action<AuthenticationOptions>? options = null)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));
        var keycloakOptions = new KeycloakAuthenticationOptions
        {

        };

        if (options != null)
            options((AuthenticationOptions)keycloakOptions);
        services.AddKeycloakAuthentication(keycloakOptions);
        return services;
    }
    /// <summary>
    /// Configura a autorização de usuário.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static WebApplicationBuilder ConfigureAuthorization(this WebApplicationBuilder builder, Action<AuthorizationOptions>? options = null)
    {
        if (builder == null) throw new ArgumentNullException(nameof(builder));
        builder.Services.ConfigureAuthorization(options);
        return builder;
    }
    /// <summary>
    /// Configura a autorização de usuário.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IServiceCollection ConfigureAuthorization(this IServiceCollection services, Action<AuthorizationOptions>? options = null)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));
        var keycloakOptions = new KeycloakProtectionClientOptions
        {

        };

        if (options != null)
            options((AuthorizationOptions)keycloakOptions);
        services.AddKeycloakAuthorization(keycloakOptions);
        return services;
    }
}