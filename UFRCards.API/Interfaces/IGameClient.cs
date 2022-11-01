namespace UFRCards.API.Interfaces;

public interface IGameClient
{
    Task ReceiveMessage(string user, string message);
}