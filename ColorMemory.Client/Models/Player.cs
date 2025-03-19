using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorMemory.Shared.Models;

public interface IPlayer
{
    int Id { get; set; }
    string Name { get; set; }
    int Score { get; set; }
    int Rank { get; set; }
}
public class Player : IPlayer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }
    public int Rank { get; set; }
    public TimeSpan Time { get; set; }
}