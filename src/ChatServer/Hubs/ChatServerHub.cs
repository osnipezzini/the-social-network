using Microsoft.AspNetCore.SignalR;

using TSN.ChatServer.Services;

namespace TSN.ChatServer.Hubs;

public class ChatServerHub : Hub
{
    private readonly HubService _hubService;
    private readonly ILogger<HubService> _logger;

    public ChatServerHub(HubService hubService, ILogger<HubService> logger)
    {
        _hubService = hubService;
        _logger = logger;
    }
    public override Task OnConnectedAsync()
    {
        var context = Context.GetHttpContext();
        var userId = Guid.Empty;
        if (context?.Request.Headers.ContainsKey("UserId") ?? false 
            && Guid.TryParse(context.Request.Headers["UserId"], out userId))
        {
            _hubService.KeepUserConnection(Context.ConnectionId, userId);
        }
        return Task.CompletedTask;
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        _logger.LogError(exception, "O usuário '{ConnectionId}' perdeu a conexão!", Context.ConnectionId);
        _hubService.RemoveUserConnection(Context.ConnectionId);
        return base.OnDisconnectedAsync(exception);
    }
}
