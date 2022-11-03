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

        var gameSession = new GameSession
        {
            Name = gameSessionDto.Name,
            CreatedAt = DateTime.UtcNow,
            IsActive = true,
            GameSessionSettings = new GameSessionSettings
            {
                MaxRounds = gameSessionDto.RoundsCount,
                PlayersCount = gameSessionDto.NumberOfPlayers,
            },
        };

        AddPlayersToSession(gameSession, gameSessionDto.Players);
        
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

    private static void AddPlayersToSession(GameSession gameSession, IEnumerable<PlayerDto> playerDtos)
    {
        var players = playerDtos
            .Select(playerDto => new Player { Name = playerDto.Name, })
            .ToList();

        gameSession.Players = players;
    }
}