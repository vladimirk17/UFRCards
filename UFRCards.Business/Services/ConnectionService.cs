using UFRCards.Business.Interfaces;
using UFRCards.Business.Models;

namespace UFRCards.Business.Services;

public class ConnectionService : IConnectionService
{
    private static readonly Dictionary<string, PlayerConnection> OnlinePlayers = new();

    public void ConnectPlayerToSession(PlayerConnection playerConnection)
    {
        lock (OnlinePlayers)
        {
            if (!OnlinePlayers.ContainsKey(playerConnection.PlayerName))
            {
                OnlinePlayers.Add(playerConnection.PlayerName, playerConnection);
            }
            else
            {
                OnlinePlayers[playerConnection.PlayerName] = playerConnection;
            }
        }
    }

    public void DisconnectPlayerFromSession(string playerName)
    {
        lock (OnlinePlayers)
        {
            if (OnlinePlayers.ContainsKey(playerName))
            {
                OnlinePlayers.Remove(playerName);
            }
        }
    }

    public IDictionary<string, string> GetOnlinePlayersByConnection()
    {
        Dictionary<string, string> result;
        lock (OnlinePlayers)
        {
            result = OnlinePlayers 
                .ToDictionary(x => x.Key, x => x.Value.ConnectionId);
        }

        return result;
    }

    public (string, int) GetPlayerNameByConnectionId(string connectionId)
    {
        (string, int) playerName;
        
        lock (OnlinePlayers)
        {
            var tmp = OnlinePlayers
                .Where(x => x.Value.ConnectionId == connectionId)
                .Select(x => new { x.Key, x.Value.GameSessionId })
                .SingleOrDefault();

            playerName = (tmp?.Key, tmp.GameSessionId);
        }

        return playerName;
    }
}