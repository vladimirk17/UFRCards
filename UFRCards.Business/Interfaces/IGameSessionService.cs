using UFRCards.Business.Dto;

namespace UFRCards.Business.Interfaces;

public interface IGameSessionService
{
    Task<int> CreateGameSession(GameSessionDto gameSessionDto);
    Task<GameSessionDto> GetGameSession(int id);
    Task AddPlayerToSession(int gameSessionId, string playerName);
    Task RemovePlayerFromSession(int gameSessionId, string playerName);
}