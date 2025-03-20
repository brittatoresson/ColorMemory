namespace ColorMemory.Shared.Models;

public interface IPlayer
{
    int Id { get; set; }
    string Name { get; set; }
    int Points { get; set; }
    int Rank { get; set; }
}
public class Player : IPlayer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Points { get; set; }
    public int Rank { get; set; }
    public long Time { get; set; }
}