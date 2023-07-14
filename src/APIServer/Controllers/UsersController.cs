using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

using TSN.Common.Requests;
using TSN.Common.Responses;

namespace TSN.APIServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IHttpContextAccessor _contextAccessor;

    public UsersController(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }
    [HttpPost]
    [Authorize]
    public async Task<UserResponse> CreateProfile(UserProfileRequest request)
    {
        await Task.CompletedTask;
        var name = _contextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.Name)!;
        var email = _contextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.Email)!;
        var id = _contextAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        return new UserResponse(Guid.Parse(id), email, name, request.Bio);
    }
}
