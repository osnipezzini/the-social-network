using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using TSN.Application.Data;
using TSN.Application.Exceptions;
using TSN.Application.Models;
using TSN.Domain.DataModels;

namespace TSN.Application.Services;

internal class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ApplicationDbContext _dbContext;

    public AuthenticationService(UserManager<User> userManager, SignInManager<User> signInManager,
        ApplicationDbContext dbContext)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _dbContext = dbContext;
    }
    public async Task<User> CreateUserAsync(UserCreateDto userDto, CancellationToken cancellationToken = default)
    {
        if (await UsernameExistsAsync(userDto.Username, cancellationToken))
            throw new UserConflictException(StringResources.UsernameConflict);

        if (await EmailExistsAsync(userDto.Email, cancellationToken))
            throw new UserConflictException(StringResources.EmailConflict);

        var user = new User
        {
            UserName = userDto.Username,
            Email = userDto.Email
        };
        var result = await _userManager.CreateAsync(user);
        if (!result.Succeeded)
            throw new AuthenticationServiceException(StringResources.CreateUserError, result.Errors);

        var passwordResult = await _userManager.AddPasswordAsync(user, userDto.Password);
        if (!passwordResult.Succeeded)
            throw new AuthenticationServiceException(StringResources.AddPasswordError, passwordResult.Errors);

        return user;
    }

    public Task<bool> EmailExistsAsync(string email, CancellationToken cancellationToken = default)
    {
        return _dbContext.Users
            .Where(user => user.Email == email)
            .AnyAsync(cancellationToken);
    }

    public Task<bool> UsernameExistsAsync(string username, CancellationToken cancellationToken = default)
    {
        return _dbContext.Users
            .Where(user => user.UserName == username)
            .AnyAsync(cancellationToken);
    }
}
