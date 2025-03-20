
namespace ColorMemory.Client.Models;

public interface ICard
{
    int Id { get; init; }
    int PairId { get; set; }
    string Color { get; set; }
    public string BgColor { get; set; }
    bool IsFlipped { get; set; }
    bool IsMatch { get; set; }
}
public class Card : ICard
{
    public int Id { get; init; } 
    public int PairId { get; set; }
    public string Color { get; set; }
    public string BgColor { get; set; }
    public bool IsFlipped { get; set; }
    public bool IsMatch { get; set; }
}

