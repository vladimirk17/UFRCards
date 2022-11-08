using UFRCards.Business.Models;

namespace UFRCards.Business.Interfaces;

public interface IConnectionService
{
    void ConnectPlayerToSession(PlayerConnection playerConnection);
    void DisconnectPlayerFromSession(PlayerConnection playerConnection);
    IDictionary<string, string> GetOnlinePlayersByConnection();
}