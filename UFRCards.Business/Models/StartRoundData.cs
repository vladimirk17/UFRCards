namespace UFRCards.Business.Models;

public class StartRoundData
{
    public string RoundQuestion { get; set; }
    public IEnumerable<string> Answers { get; set; } 
}