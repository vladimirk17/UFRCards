using UFRCards.Business.Models;

namespace UFRCards.Business.Interfaces;

public interface IConnectionService
{
    void ConnectPlayerToSession(PlayerConnection playerConnection);
    void DisconnectPlayerFromSession(string playerName);
    IDictionary<string, string> GetOnlinePlayersByConnection();
    string GetPlayerNameByConnectionId(string connectionId);
}