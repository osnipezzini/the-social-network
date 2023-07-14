using TSN.Application.Exceptions;
using TSN.Application.Models;
using TSN.Domain.DataModels;

namespace TSN.Application.Services;

public interface IAuthenticationService
{
    /// <summary>
    /// Create a user
    /// </summary>
    /// <param name="userDto">User data</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="UserConflictException"></exception>
    /// <exception cref="AuthenticationServiceException"></exception>
    Task<User> CreateUserAsync(UserCreateDto userDto, CancellationToken cancellationToken = default);
    /// <summary>
    /// Check if username exists
    /// </summary>
    /// <param name="username"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> UsernameExistsAsync(string username, CancellationToken cancellationToken = default);
    /// <summary>
    /// Check if email exists
    /// </summary>
    /// <param name="email"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken = default);
}
