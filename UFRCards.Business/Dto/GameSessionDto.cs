namespace UFRCards.Business.Dto;

public class GameSessionDto
{
    public string Name { get; init; }
    public int NumberOfPlayers { get; init; }
    public int RoundsCount { get; init; }
    public List<PlayerDto> Players { get; set; }
}