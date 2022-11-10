using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using UFRCards.API.Interfaces;
using UFRCards.Business.Interfaces;
using UFRCards.Business.Models;
using UFRCards.Data;
using UFRCards.Data.Enums;

namespace UFRCards.API.Hubs;

public class GameHub : Hub<IGameClient>
{
    private readonly Context _context;
    private readonly IConnectionService _connectionService;
    private readonly ILogger<GameHub> _logger;
    private readonly IGameSessionService _gameSessionService;
    private const string System = "SYSTEM";

    public GameHub(
        ILogger<GameHub> logger, 
        IGameSessionService gameSessionService, 
        Context context,
        IConnectionService connectionService)
    {
        _logger = logger;
        _gameSessionService = gameSessionService;
        _context = context;
        _connectionService = connectionService;
    }

    public async Task JoinSession(PlayerConnection playerConnection)
    {
        var sessionId = playerConnection.GameSessionId;
        var playerName = playerConnection.PlayerName;
        try
        {
            await _gameSessionService.AddPlayerToSession(sessionId, playerName);
        }
        catch //TODO need custom exception here
        {
            _logger.LogError("Problem adding new player to session {SessionId}", sessionId);
        }
        
        await Groups.AddToGroupAsync(Context.ConnectionId, sessionId.ToString());

        playerConnection.ConnectionId = Context.ConnectionId;
        _connectionService.ConnectPlayerToSession(playerConnection);

        _logger.LogDebug("{PlayerName} connected", playerName);
        Console.WriteLine($"{playerName} connected");
        
        await Clients.Group(sessionId.ToString()).ReceiveNotification(System,
            $"{playerConnection.PlayerName} connected to session {sessionId}");
    }

    public async Task StartGame(int gameSessionId)
    {
        var session = await _context.GameSessions
            .AsNoTracking()
            .Include(x => x.Players)
            .Include(x => x.Questions)
            .SingleOrDefaultAsync(x => x.Id == gameSessionId);

        if (session == null)
        {
            throw new ArgumentException();
        }
        
        session.GameSessionStatus = GameSessionStatus.InProgress;

        var question = session.Questions.First();

        var answers = await _context.Answers
            .Where(x => x.QuestionCategory == session.GameSessionSettings.QuestionCategory)
            .Take(session.GameSessionSettings.PlayersCount)
            .ToArrayAsync();

        var connectionsByPlayers = _connectionService.GetOnlinePlayersByConnection();

        foreach (var player in session.Players)
        {
            var roundData = new StartRoundData
            {
                RoundQuestion = question.QuestionText,
                Answers = answers.Select(x => x.AnswerText),
            };
            
            await Clients.Client(connectionsByPlayers[player.Name]).ReceiveStartRoundData(roundData);
        }
        
    }

    public async Task SendMessage(string groupName, string user, string message)
    {
        await Clients.Group(groupName).ReceiveNotification(user, message);
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        var (playerName, sessionId) = _connectionService.GetPlayerNameByConnectionId(Context.ConnectionId);

        await _gameSessionService.RemovePlayerFromSession(sessionId, playerName);
        _connectionService.DisconnectPlayerFromSession(playerName);
        
        _logger.LogDebug("{PlayerName} disconnected", playerName);
        Console.WriteLine($"{playerName} disconnected");
        await Clients.All.ReceiveNotification(System, $"{playerName} disconnected");
        
        await base.OnDisconnectedAsync(exception);
    }
}