using Microsoft.AspNetCore.Mvc;

using TSN.Common.Requests;
using TSN.Common.Responses;

namespace TSN.APIServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<UserResponse> Authenticate(LoginRequest request)
        {
            await Task.CompletedTask;
            return null;
        }
    }
}
