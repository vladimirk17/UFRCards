using UFRCards.Business.Models;

namespace UFRCards.API.Interfaces;

public interface IGameClient
{
    Task ReceiveNotification(string user, string message);
    Task ReceiveStartRoundData(StartRoundData startRoundData);
    Task FinishGameRound(int roundId);
}