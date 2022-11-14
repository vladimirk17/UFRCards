namespace UFRCards.Data.Interfaces;

public interface IHasId<T> where T : struct
{
    T Id { get; set; }
}