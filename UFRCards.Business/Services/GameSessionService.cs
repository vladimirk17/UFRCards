using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UFRCards.Business.Dto;
using UFRCards.Business.Interfaces;
using UFRCards.Data;
using UFRCards.Data.Entities;

namespace UFRCards.Business.Services;

public class GameSessionService : IGameSessionService
{
    private readonly Context _context;
    private readonly IMapper _mapper;

    public GameSessionService(Context context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<int> CreateGameSession(GameSessionDto gameSessionDto)
    {
        if (gameSessionDto == null)
        {
            throw new ArgumentNullException(nameof(gameSessionDto));
        }

        var questions = await _context.Questions
            .Where(x => x.QuestionCategory == gameSessionDto.QuestionCategory)
            .Take(gameSessionDto.RoundsCount)
            .ToArrayAsync();
        
        var gameSession = new GameSession
        {
            Name = gameSessionDto.Name,
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            GameSessionSettings = new GameSessionSettings
            {
                MaxRounds = gameSessionDto.RoundsCount,
                PlayersCount = gameSessionDto.NumberOfPlayers,
                QuestionCategory = gameSessionDto.QuestionCategory,
            },
            Questions = questions,
        };

        // AddPlayersToSession(gameSession, gameSessionDto.Players);
        
        // var gameSession = _mapper.Map<GameSession>(gameSessionDto);

        _context.GameSessions.Add(gameSession);
        await _context.SaveChangesAsync();

        return gameSession.Id;
    }

    public async Task<GameSessionDto> GetGameSession(int id)
    {
        var gameSession = await _context.GameSessions
            .AsNoTracking()
            .Include(x => x.Players)
            .SingleOrDefaultAsync(x => x.Id == id);

        if (gameSession == null)
        {
            throw new KeyNotFoundException();
        }

        // var gameSessionDto = _mapper.Map<GameSessionDto>(gameSession);

        var gameSessionDto = new GameSessionDto
        {
            Name = gameSession.Name,
            NumberOfPlayers = gameSession.GameSessionSettings.PlayersCount,
            RoundsCount = gameSession.GameSessionSettings.MaxRounds,
            Players = new List<PlayerDto>
            {
                new() { Name = gameSession.Players.FirstOrDefault()?.Name }
            }
        };

        return gameSessionDto;
    }

    public async Task AddPlayerToSession(int gameSessionId, string playerName)
    {
        var gameSession = await _context.GameSessions
            .Include(x => x.Players)
            .Where(x => x.Id == gameSessionId)
            .SingleOrDefaultAsync();
        
        if (gameSession == null)
        {
            throw new KeyNotFoundException();
        }

        if (gameSession.GameSessionSettings.PlayersCount >= gameSession.GameSessionSettings.MaxPlayers)
        {
            throw new ArgumentException(); //TODO need custom ex class here
        }
        
        var newPlayer = new Player { Name = playerName };
        gameSession.Players.Add(newPlayer);
        gameSession.GameSessionSettings.PlayersCount++;
        await _context.SaveChangesAsync();
    }

    public async Task RemovePlayerFromSession(int gameSessionId, string playerName)
    {
        var gameSession = await _context.GameSessions
            .Include(x => x.Players)
            .Where(x => x.Id == gameSessionId)
            .SingleOrDefaultAsync();

        var playerToRemove = gameSession.Players?.SingleOrDefault(x => x.Name == playerName);

        gameSession.Players?.Remove(playerToRemove);
        gameSession.GameSessionSettings.PlayersCount--;

        await _context.SaveChangesAsync();
    }
    
    private static void AddPlayersToSession(GameSession gameSession, IEnumerable<PlayerDto> playerDtos)
    {
        var players = playerDtos
            .Select(playerDto => new Player { Name = playerDto.Name, })
            .ToList();

        gameSession.Players = players;
    }
}