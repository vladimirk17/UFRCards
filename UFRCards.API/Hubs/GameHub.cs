using Microsoft.AspNetCore.SignalR;
using UFRCards.API.Interfaces;

namespace UFRCards.API.Hubs;

public class GameHub : Hub<IGameClient>
{
    private readonly ILogger<GameHub> _logger;

    public GameHub(ILogger<GameHub> logger)
    {
        _logger = logger;
    }
    
    public async Task SendMessage(string user, string message) => 
        await Clients.Group("Game Session Group").ReceiveMessage(user, message);

    public override async Task OnConnectedAsync()
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, "Game Session Group");
        await base.OnConnectedAsync();
    }
    
    public override async Task OnDisconnectedAsync(Exception exception)
    {
        if (!string.IsNullOrWhiteSpace(exception.Message))
        {
            _logger.LogError(exception.Message);
        }
        
        
        await base.OnDisconnectedAsync(exception);
    }
}